"use client"

import { Button } from "@/components/ui/button"
import { Input } from "@/components/ui/input"
import { Label } from "@/components/ui/label"
import { Textarea } from "@/components/ui/textarea"
import { Card } from "@/components/ui/card"
import { PlusCircle, Trash2 } from "lucide-react"
import type { CVData, WorkExperience } from "@/types"

interface ExperienceFormProps {
  data: CVData
  onChange: (data: Partial<CVData>) => void
}

export function ExperienceForm({ data, onChange }: ExperienceFormProps) {
  const addExperience = () => {
    onChange({
      experience: [
        ...data.experience,
        { id: Date.now(), role: "", company: "", startDate: "", endDate: "", description: "", achievements: "" },
      ],
    })
  }

  const updateExperience = (id: number, field: keyof WorkExperience, value: string) => {
    onChange({
      experience: data.experience.map((exp) => (exp.id === id ? { ...exp, [field]: value } : exp)),
    })
  }

  const removeExperience = (id: number) => {
    onChange({
      experience: data.experience.filter((exp) => exp.id !== id),
    })
  }

  return (
    <div className="space-y-4">
      <div className="flex items-center justify-between">
        <Label>Experiencia Laboral</Label>
        <Button type="button" variant="outline" size="sm" onClick={addExperience}>
          <PlusCircle className="h-4 w-4 mr-2" />
          Agregar
        </Button>
      </div>

      {data.experience.length === 0 ? (
        <p className="text-sm text-muted-foreground text-center py-8">
          No has agregado ninguna experiencia laboral aún
        </p>
      ) : (
        <div className="space-y-4">
          {data.experience.map((exp) => (
            <Card key={exp.id} className="p-4">
              <div className="space-y-3">
                <div className="flex justify-between items-start">
                  <Label className="text-sm font-semibold">Experiencia</Label>
                  <Button type="button" variant="ghost" size="sm" onClick={() => removeExperience(exp.id)}>
                    <Trash2 className="h-4 w-4" />
                  </Button>
                </div>

                <Input
                  placeholder="Puesto"
                  value={exp.role}
                  onChange={(e) => updateExperience(exp.id, "role", e.target.value)}
                />
                <Input
                  placeholder="Empresa"
                  value={exp.company}
                  onChange={(e) => updateExperience(exp.id, "company", e.target.value)}
                />
                <div className="grid grid-cols-2 gap-3">
                  <Input
                    type="date"
                    placeholder="Fecha inicio"
                    value={exp.startDate}
                    onChange={(e) => updateExperience(exp.id, "startDate", e.target.value)}
                  />
                  <Input
                    type="date"
                    placeholder="Fecha fin"
                    value={exp.endDate}
                    onChange={(e) => updateExperience(exp.id, "endDate", e.target.value)}
                  />
                </div>
                <Textarea
                  placeholder="Responsabilidades"
                  value={exp.description}
                  onChange={(e) => updateExperience(exp.id, "description", e.target.value)}
                  rows={3}
                />
                <Textarea
                  placeholder="Logros (opcional)"
                  value={exp.achievements}
                  onChange={(e) => updateExperience(exp.id, "achievements", e.target.value)}
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
