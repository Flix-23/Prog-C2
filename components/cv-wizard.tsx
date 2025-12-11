"use client"

import { useState } from "react"
import { useRouter } from "next/navigation"
import { Button } from "@/components/ui/button"
import { Card } from "@/components/ui/card"
import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/components/ui/tabs"
import { PersonalDataForm } from "@/components/forms/personal-data-form"
import { ProfileForm } from "@/components/forms/profile-form"
import { EducationForm } from "@/components/forms/education-form"
import { ExperienceForm } from "@/components/forms/experience-form"
import { SkillsForm } from "@/components/forms/skills-form"
import { CVPreview } from "@/components/cv-preview"
import { createCV, updateCV } from "@/lib/api"
import type { CVData, Resume } from "@/types"
import { ArrowLeft, ArrowRight, Save } from "lucide-react"

interface CVWizardProps {
  initialData?: Resume | null
  isEditing?: boolean
}

const steps = [
  { id: "personal", label: "Datos Personales" },
  { id: "profile", label: "Perfil" },
  { id: "education", label: "Educación" },
  { id: "experience", label: "Experiencia" },
  { id: "skills", label: "Habilidades" },
]

export function CVWizard({ initialData, isEditing }: CVWizardProps) {
  const router = useRouter()
  const [activeStep, setActiveStep] = useState("personal")
  const [loading, setLoading] = useState(false)
  const [cvData, setCvData] = useState<CVData>({
    fullName: initialData?.fullName || "",
    degree: initialData?.degree || "",
    professionalSummary: initialData?.professionalSummary || "",
    email: "",
    phone: "",
    city: "",
    linkedin: "",
    github: "",
    education: [],
    experience: [],
    skills: [],
    languages: [],
    projects: [],
  })

  const handleDataChange = (data: Partial<CVData>) => {
    setCvData({ ...cvData, ...data })
  }

  const handleNext = () => {
    const currentIndex = steps.findIndex((s) => s.id === activeStep)
    if (currentIndex < steps.length - 1) {
      setActiveStep(steps[currentIndex + 1].id)
    }
  }

  const handlePrevious = () => {
    const currentIndex = steps.findIndex((s) => s.id === activeStep)
    if (currentIndex > 0) {
      setActiveStep(steps[currentIndex - 1].id)
    }
  }

  const handleSave = async () => {
    try {
      setLoading(true)
      
      // Validar que FullName y Degree no estén vacíos
      if (!cvData.fullName.trim()) {
        alert("El nombre completo es requerido")
        setLoading(false)
        return
      }
      if (!cvData.degree.trim()) {
        alert("El título/grado es requerido")
        setLoading(false)
        return
      }

      const requestData = {
        fullName: cvData.fullName,
        degree: cvData.degree,
        professionalSummary: cvData.professionalSummary || undefined,
        email: cvData.email || undefined,
        phone: cvData.phone || undefined,
        location: cvData.city || undefined,
        linkedin: cvData.linkedin || undefined,
        portfolio: cvData.github || undefined,
        educationRecords: [],
        workExperiences: [],
        skills: [],
      }

      if (isEditing && initialData) {
        await updateCV(initialData.id, requestData)
      } else {
        const result = await createCV(requestData)
        console.log("CV creado exitosamente:", result)
      }

      // Redirigir al dashboard
      setTimeout(() => {
        router.push("/dashboard")
      }, 500)
    } catch (error) {
      console.error("Error detallado al guardar CV:", error)
      const errorMsg = error instanceof Error ? error.message : String(error)
      alert(`Error al guardar el CV: ${errorMsg}`)
    } finally {
      setLoading(false)
    }
  }

  const currentIndex = steps.findIndex((s) => s.id === activeStep)

  return (
    <div className="space-y-6">
      <div className="flex items-center justify-between">
        <div>
          <h1 className="text-3xl font-bold">{isEditing ? "Editar CV" : "Crear nuevo CV"}</h1>
          <p className="text-muted-foreground mt-1">Completa la información para generar tu currículum profesional</p>
        </div>
        <Button onClick={handleSave} disabled={loading}>
          <Save className="h-4 w-4 mr-2" />
          {loading ? "Guardando..." : "Guardar CV"}
        </Button>
      </div>

      <div className="grid lg:grid-cols-2 gap-6">
        {/* Form Section */}
        <Card className="p-6">
          <Tabs value={activeStep} onValueChange={setActiveStep}>
            <TabsList className="grid w-full grid-cols-5 mb-6">
              {steps.map((step, index) => (
                <TabsTrigger key={step.id} value={step.id} className="text-xs" disabled={index > currentIndex + 1}>
                  {step.label}
                </TabsTrigger>
              ))}
            </TabsList>

            <TabsContent value="personal">
              <PersonalDataForm data={cvData} onChange={handleDataChange} />
            </TabsContent>

            <TabsContent value="profile">
              <ProfileForm data={cvData} onChange={handleDataChange} />
            </TabsContent>

            <TabsContent value="education">
              <EducationForm data={cvData} onChange={handleDataChange} />
            </TabsContent>

            <TabsContent value="experience">
              <ExperienceForm data={cvData} onChange={handleDataChange} />
            </TabsContent>

            <TabsContent value="skills">
              <SkillsForm data={cvData} onChange={handleDataChange} />
            </TabsContent>
          </Tabs>

          {/* Navigation */}
          <div className="flex justify-between mt-6 pt-6 border-t border-border">
            <Button variant="outline" onClick={handlePrevious} disabled={currentIndex === 0}>
              <ArrowLeft className="h-4 w-4 mr-2" />
              Anterior
            </Button>
            <Button onClick={handleNext} disabled={currentIndex === steps.length - 1}>
              Siguiente
              <ArrowRight className="h-4 w-4 ml-2" />
            </Button>
          </div>
        </Card>

        {/* Preview Section */}
        <div className="lg:sticky lg:top-6 h-fit">
          <CVPreview data={cvData} />
        </div>
      </div>
    </div>
  )
}
