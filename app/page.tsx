import Link from "next/link"
import { Button } from "@/components/ui/button"
import { Card } from "@/components/ui/card"
import { FileText, Sparkles, Download, CheckCircle } from "lucide-react"

export default function HomePage() {
  return (
    <div className="min-h-screen bg-background">
      {/* Header */}
      <header className="border-b border-border">
        <div className="container mx-auto px-4 py-4 flex items-center justify-between">
          <div className="flex items-center gap-2">
            <FileText className="h-6 w-6 text-primary" />
            <span className="text-xl font-bold">CvAlInstante</span>
          </div>
          <Link href="/dashboard">
            <Button>Ir al Dashboard</Button>
          </Link>
        </div>
      </header>

      {/* Hero Section */}
      <section className="container mx-auto px-4 py-20 md:py-32">
        <div className="max-w-4xl mx-auto text-center">
          <h1 className="text-4xl md:text-6xl font-bold mb-6 text-balance">Crea tu CV profesional en minutos</h1>
          <p className="text-xl text-muted-foreground mb-8 text-pretty">
            CvAlInstante es el generador de currículums pensado para estudiantes y jóvenes profesionales. Rápido,
            profesional y completamente personalizable.
          </p>
          <div className="flex flex-col sm:flex-row gap-4 justify-center">
            <Link href="/cv/nuevo">
              <Button size="lg" className="w-full sm:w-auto">
                Comenzar ahora
              </Button>
            </Link>
            <Link href="/plantillas">
              <Button size="lg" variant="outline" className="w-full sm:w-auto bg-transparent">
                Ver plantillas
              </Button>
            </Link>
          </div>
        </div>
      </section>

      {/* Benefits Section */}
      <section className="container mx-auto px-4 py-16">
        <div className="grid md:grid-cols-3 gap-8 max-w-5xl mx-auto">
          <Card className="p-6">
            <div className="h-12 w-12 rounded-lg bg-primary/10 flex items-center justify-center mb-4">
              <Sparkles className="h-6 w-6 text-primary" />
            </div>
            <h3 className="text-xl font-semibold mb-2">Rápido</h3>
            <p className="text-muted-foreground">
              Completa tu información en pocos minutos con nuestro wizard intuitivo paso a paso.
            </p>
          </Card>

          <Card className="p-6">
            <div className="h-12 w-12 rounded-lg bg-primary/10 flex items-center justify-center mb-4">
              <CheckCircle className="h-6 w-6 text-primary" />
            </div>
            <h3 className="text-xl font-semibold mb-2">Profesional</h3>
            <p className="text-muted-foreground">
              Plantillas diseñadas por expertos que destacan tu experiencia y habilidades.
            </p>
          </Card>

          <Card className="p-6">
            <div className="h-12 w-12 rounded-lg bg-primary/10 flex items-center justify-center mb-4">
              <Download className="h-6 w-6 text-primary" />
            </div>
            <h3 className="text-xl font-semibold mb-2">Personalizable</h3>
            <p className="text-muted-foreground">
              Elige entre diferentes plantillas y descarga tu CV en PDF al instante.
            </p>
          </Card>
        </div>
      </section>

      {/* Steps Section */}
      <section className="container mx-auto px-4 py-16 bg-muted/30">
        <div className="max-w-4xl mx-auto">
          <h2 className="text-3xl font-bold text-center mb-12">Cómo funciona</h2>
          <div className="space-y-8">
            <div className="flex gap-6 items-start">
              <div className="h-12 w-12 rounded-full bg-primary text-primary-foreground flex items-center justify-center font-bold flex-shrink-0">
                1
              </div>
              <div>
                <h3 className="text-xl font-semibold mb-2">Completa tus datos</h3>
                <p className="text-muted-foreground">
                  Ingresa tu información personal, educación, experiencia laboral y habilidades en nuestro formulario
                  guiado.
                </p>
              </div>
            </div>

            <div className="flex gap-6 items-start">
              <div className="h-12 w-12 rounded-full bg-primary text-primary-foreground flex items-center justify-center font-bold flex-shrink-0">
                2
              </div>
              <div>
                <h3 className="text-xl font-semibold mb-2">Elige tu plantilla</h3>
                <p className="text-muted-foreground">
                  Selecciona entre nuestras plantillas profesionales y previsualiza tu CV en tiempo real.
                </p>
              </div>
            </div>

            <div className="flex gap-6 items-start">
              <div className="h-12 w-12 rounded-full bg-primary text-primary-foreground flex items-center justify-center font-bold flex-shrink-0">
                3
              </div>
              <div>
                <h3 className="text-xl font-semibold mb-2">Descarga tu CV</h3>
                <p className="text-muted-foreground">
                  Genera y descarga tu currículum en PDF, listo para enviar a empresas.
                </p>
              </div>
            </div>
          </div>
        </div>
      </section>

      {/* CTA Section */}
      <section className="container mx-auto px-4 py-20">
        <div className="max-w-3xl mx-auto text-center bg-primary text-primary-foreground rounded-xl p-12">
          <h2 className="text-3xl font-bold mb-4">¿Listo para crear tu CV?</h2>
          <p className="text-lg mb-8 opacity-90">
            Únete a miles de profesionales que han creado su currículum con CvAlInstante
          </p>
          <Link href="/cv/nuevo">
            <Button size="lg" variant="secondary">
              Crear mi CV gratis
            </Button>
          </Link>
        </div>
      </section>

      {/* Footer */}
      <footer className="border-t border-border py-8">
        <div className="container mx-auto px-4 text-center text-muted-foreground">
          <p>© 2025 CvAlInstante. Tu carrera profesional comienza aquí.</p>
        </div>
      </footer>
    </div>
  )
}
