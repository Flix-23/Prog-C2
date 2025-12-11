import { FileText } from "lucide-react"
import Link from "next/link"
import { Button } from "@/components/ui/button"

export function EmptyState() {
  return (
    <div className="text-center py-12 px-4">
      <div className="inline-flex items-center justify-center h-16 w-16 rounded-full bg-muted mb-4">
        <FileText className="h-8 w-8 text-muted-foreground" />
      </div>
      <h3 className="text-lg font-semibold mb-2">No tienes CVs creados</h3>
      <p className="text-muted-foreground mb-6">Comienza creando tu primer currículum profesional en minutos</p>
      <Link href="/cv/nuevo">
        <Button>Crear mi primer CV</Button>
      </Link>
    </div>
  )
}
