"use client"

import { useState, useEffect } from "react"
import { useParams } from "next/navigation"
import { CVWizard } from "@/components/cv-wizard"
import { DashboardLayout } from "@/components/dashboard-layout"
import { getCVById } from "@/lib/api"
import type { Resume } from "@/types"

export default function EditCVPage() {
  const params = useParams()
  const [resume, setResume] = useState<Resume | null>(null)
  const [loading, setLoading] = useState(true)

  useEffect(() => {
    loadResume()
  }, [])

  const loadResume = async () => {
    try {
      const id = Number(params.id)
      const data = await getCVById(id)
      setResume(data)
    } catch (error) {
      console.error("Error al cargar CV:", error)
    } finally {
      setLoading(false)
    }
  }

  if (loading) {
    return (
      <DashboardLayout>
        <div className="text-center py-12">
          <p className="text-muted-foreground">Cargando CV...</p>
        </div>
      </DashboardLayout>
    )
  }

  return (
    <DashboardLayout>
      <CVWizard initialData={resume} isEditing />
    </DashboardLayout>
  )
}
