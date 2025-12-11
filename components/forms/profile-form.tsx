"use client"

import { Textarea } from "@/components/ui/textarea"
import { Label } from "@/components/ui/label"
import type { CVData } from "@/types"

interface ProfileFormProps {
  data: CVData
  onChange: (data: Partial<CVData>) => void
}

export function ProfileForm({ data, onChange }: ProfileFormProps) {
  const charCount = data.professionalSummary.length

  return (
    <div className="space-y-4">
      <div>
        <Label htmlFor="professionalSummary">Resumen Profesional</Label>
        <p className="text-sm text-muted-foreground mb-2">
          Describe tu experiencia, habilidades clave y objetivos profesionales. (200-800 caracteres)
        </p>
        <Textarea
          id="professionalSummary"
          value={data.professionalSummary}
          onChange={(e) => onChange({ professionalSummary: e.target.value })}
          placeholder="Ej: Desarrolladora Full Stack con 3 años de experiencia en creación de aplicaciones web modernas..."
          rows={8}
          minLength={200}
          maxLength={800}
        />
        <p className="text-sm text-muted-foreground mt-1">
          {charCount}/800 caracteres {charCount < 200 && `(mínimo 200)`}
        </p>
      </div>
    </div>
  )
}
