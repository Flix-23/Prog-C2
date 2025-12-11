import { Card } from "@/components/ui/card"
import { Button } from "@/components/ui/button"
import { DashboardLayout } from "@/components/dashboard-layout"
import { CheckCircle } from "lucide-react"

const templates = [
  {
    id: "elegante",
    name: "Elegante",
    description: "Diseño clásico y profesional, ideal para puestos corporativos",
    preview: "/elegant-professional-resume-template.jpg",
  },
  {
    id: "minimal",
    name: "Minimal",
    description: "Diseño limpio y moderno, perfecto para creativos y tech",
    preview: "/minimal-modern-resume-template.jpg",
  },
  {
    id: "creativa",
    name: "Creativa",
    description: "Diseño con personalidad para destacar en industrias creativas",
    preview: "/creative-colorful-resume.png",
  },
  {
    id: "profesional",
    name: "Profesional",
    description: "Balance perfecto entre formalidad y modernidad",
    preview: "/professional-business-resume-template.jpg",
  },
]

export default function PlantillasPage() {
  return (
    <DashboardLayout>
      <div className="space-y-6">
        <div>
          <h1 className="text-3xl font-bold">Plantillas</h1>
          <p className="text-muted-foreground mt-1">Elige la plantilla que mejor se adapte a tu estilo profesional</p>
        </div>

        <div className="grid md:grid-cols-2 lg:grid-cols-4 gap-6">
          {templates.map((template) => (
            <Card key={template.id} className="overflow-hidden hover:shadow-lg transition-shadow">
              <div className="aspect-[3/4] bg-muted relative">
                <img
                  src={template.preview || "/placeholder.svg"}
                  alt={template.name}
                  className="w-full h-full object-cover"
                />
              </div>
              <div className="p-4">
                <h3 className="font-semibold text-lg mb-1">{template.name}</h3>
                <p className="text-sm text-muted-foreground mb-4 line-clamp-2">{template.description}</p>
                <Button className="w-full bg-transparent" variant="outline">
                  <CheckCircle className="h-4 w-4 mr-2" />
                  Usar plantilla
                </Button>
              </div>
            </Card>
          ))}
        </div>
      </div>
    </DashboardLayout>
  )
}
