"use client"

import { Button } from "@/components/ui/button"
import { Input } from "@/components/ui/input"
import { Label } from "@/components/ui/label"
import { Textarea } from "@/components/ui/textarea"
import { Card } from "@/components/ui/card"
import { PlusCircle, Trash2 } from "lucide-react"
import type { CVData, EducationRecord } from "@/types"

interface EducationFormProps {
  data: CVData
  onChange: (data: Partial<CVData>) => void
}

export function EducationForm({ data, onChange }: EducationFormProps) {
  const addEducation = () => {
    onChange({
      education: [
        ...data.education,
        { id: Date.now(), title: "", institution: "", startDate: "", endDate: "", description: "" },
      ],
    })
  }

  const updateEducation = (id: number, field: keyof EducationRecord, value: string) => {
    onChange({
      education: data.education.map((edu) => (edu.id === id ? { ...edu, [field]: value } : edu)),
    })
  }

  const removeEducation = (id: number) => {
    onChange({
      education: data.education.filter((edu) => edu.id !== id),
    })
  }

  return (
    <div className="space-y-4">
      <div className="flex items-center justify-between">
        <Label>Formación Académica</Label>
        <Button type="button" variant="outline" size="sm" onClick={addEducation}>
          <PlusCircle className="h-4 w-4 mr-2" />
          Agregar
        </Button>
      </div>

      {data.education.length === 0 ? (
        <p className="text-sm text-muted-foreground text-center py-8">
          No has agregado ninguna formación académica aún
        </p>
      ) : (
        <div className="space-y-4">
          {data.education.map((edu) => (
            <Card key={edu.id} className="p-4">
              <div className="space-y-3">
                <div className="flex justify-between items-start">
                  <Label className="text-sm font-semibold">Educación</Label>
                  <Button type="button" variant="ghost" size="sm" onClick={() => removeEducation(edu.id)}>
                    <Trash2 className="h-4 w-4" />
                  </Button>
                </div>

                <Input
                  placeholder="Título / Carrera"
                  value={edu.title}
                  onChange={(e) => updateEducation(edu.id, "title", e.target.value)}
                />
                <Input
                  placeholder="Institución"
                  value={edu.institution}
                  onChange={(e) => updateEducation(edu.id, "institution", e.target.value)}
                />
                <div className="grid grid-cols-2 gap-3">
                  <Input
                    type="date"
                    placeholder="Fecha inicio"
                    value={edu.startDate}
                    onChange={(e) => updateEducation(edu.id, "startDate", e.target.value)}
                  />
                  <Input
                    type="date"
                    placeholder="Fecha fin"
                    value={edu.endDate}
                    onChange={(e) => updateEducation(edu.id, "endDate", e.target.value)}
                  />
                </div>
                <Textarea
                  placeholder="Descripción breve (opcional)"
                  value={edu.description}
                  onChange={(e) => updateEducation(edu.id, "description", e.target.value)}
                  rows={2}
                />
              </div>
            </Card>
          ))}
        </div>
      )}
    </div>
  )
}
