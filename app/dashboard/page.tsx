"use client"

import { useState, useEffect } from "react"
import Link from "next/link"
import { Button } from "@/components/ui/button"
import { Card } from "@/components/ui/card"
import { PlusCircle, FileText, Edit, Trash2, Download, AlertCircle } from "lucide-react"
import { DashboardLayout } from "@/components/dashboard-layout"
import { EmptyState } from "@/components/empty-state"
import { ConfirmDialog } from "@/components/confirm-dialog"
import { getCVs, deleteCV } from "@/lib/api"
import type { Resume } from "@/types"

export default function DashboardPage() {
  const [resumes, setResumes] = useState<Resume[]>([])
  const [loading, setLoading] = useState(true)
  const [deleteId, setDeleteId] = useState<number | null>(null)
  const [error, setError] = useState<string | null>(null)

  useEffect(() => {
    loadResumes()
  }, [])

  const loadResumes = async () => {
    try {
      setLoading(true)
      setError(null)
      const data = await getCVs()
      setResumes(data)
    } catch (error) {
      console.error("Error al cargar CVs:", error)
      setError(
        "No se puede conectar con el servidor. Asegúrate de que el backend esté corriendo en http://localhost:5000",
      )
    } finally {
      setLoading(false)
    }
  }

  const handleDelete = async (id: number) => {
    try {
      await deleteCV(id)
      setResumes(resumes.filter((r) => r.id !== id))
      setDeleteId(null)
    } catch (error) {
      console.error("Error al eliminar CV:", error)
      setError("Error al eliminar el CV. Verifica la conexión con el servidor.")
    }
  }

  return (
    <DashboardLayout>
      <div className="space-y-6">
        <div className="flex items-center justify-between">
          <div>
            <h1 className="text-3xl font-bold">Dashboard</h1>
            <p className="text-muted-foreground mt-1">Gestiona tus currículums profesionales</p>
          </div>
          <Link href="/cv/nuevo">
            <Button size="lg">
              <PlusCircle className="h-5 w-5 mr-2" />
              Crear nuevo CV
            </Button>
          </Link>
        </div>

        {error && (
          <Card className="p-4 border-destructive bg-destructive/10">
            <div className="flex items-start gap-3">
              <AlertCircle className="h-5 w-5 text-destructive mt-0.5" />
              <div className="flex-1">
                <p className="font-medium text-destructive">Error de conexión</p>
                <p className="text-sm text-destructive/80 mt-1">{error}</p>
              </div>
              <Button variant="outline" size="sm" onClick={loadResumes}>
                Reintentar
              </Button>
            </div>
          </Card>
        )}

        {/* Stats */}
        <div className="grid md:grid-cols-3 gap-6">
          <Card className="p-6">
            <div className="flex items-center gap-4">
              <div className="h-12 w-12 rounded-lg bg-primary/10 flex items-center justify-center">
                <FileText className="h-6 w-6 text-primary" />
              </div>
              <div>
                <p className="text-sm text-muted-foreground">CVs creados</p>
                <p className="text-2xl font-bold">{resumes.length}</p>
              </div>
            </div>
          </Card>

          <Card className="p-6">
            <div className="flex items-center gap-4">
              <div className="h-12 w-12 rounded-lg bg-primary/10 flex items-center justify-center">
                <Edit className="h-6 w-6 text-primary" />
              </div>
              <div>
                <p className="text-sm text-muted-foreground">Última actualización</p>
                <p className="text-2xl font-bold">Hoy</p>
              </div>
            </div>
          </Card>

          <Card className="p-6">
            <div className="flex items-center gap-4">
              <div className="h-12 w-12 rounded-lg bg-primary/10 flex items-center justify-center">
                <Download className="h-6 w-6 text-primary" />
              </div>
              <div>
                <p className="text-sm text-muted-foreground">Descargas</p>
                <p className="text-2xl font-bold">{resumes.length * 2}</p>
              </div>
            </div>
          </Card>
        </div>

        {/* CV List */}
        <div>
          <h2 className="text-xl font-semibold mb-4">Mis CVs</h2>
          {loading ? (
            <div className="text-center py-12">
              <p className="text-muted-foreground">Cargando...</p>
            </div>
          ) : resumes.length === 0 ? (
            <EmptyState />
          ) : (
            <div className="grid md:grid-cols-2 lg:grid-cols-3 gap-6">
              {resumes.map((resume) => (
                <Card key={resume.id} className="p-6 hover:shadow-lg transition-shadow">
                  <div className="flex items-start justify-between mb-4">
                    <div className="h-12 w-12 rounded-lg bg-primary/10 flex items-center justify-center">
                      <FileText className="h-6 w-6 text-primary" />
                    </div>
                  </div>
                  <h3 className="font-semibold text-lg mb-1">{resume.fullName}</h3>
                  <p className="text-sm text-muted-foreground mb-4">{resume.degree}</p>
                  <div className="flex gap-2">
                    <Link href={`/cv/${resume.id}/editar`} className="flex-1">
                      <Button variant="outline" size="sm" className="w-full bg-transparent">
                        <Edit className="h-4 w-4 mr-2" />
                        Editar
                      </Button>
                    </Link>
                    <Button variant="outline" size="sm" onClick={() => setDeleteId(resume.id)}>
                      <Trash2 className="h-4 w-4" />
                    </Button>
                  </div>
                </Card>
              ))}
            </div>
          )}
        </div>
      </div>

      <ConfirmDialog
        open={deleteId !== null}
        onClose={() => setDeleteId(null)}
        onConfirm={() => deleteId && handleDelete(deleteId)}
        title="¿Eliminar CV?"
        description="Esta acción no se puede deshacer. El CV será eliminado permanentemente."
      />
    </DashboardLayout>
  )
}
