"use client"

import { Input } from "@/components/ui/input"
import { Label } from "@/components/ui/label"
import type { CVData } from "@/types"

interface PersonalDataFormProps {
  data: CVData
  onChange: (data: Partial<CVData>) => void
}

export function PersonalDataForm({ data, onChange }: PersonalDataFormProps) {
  return (
    <div className="space-y-4">
      <div>
        <Label htmlFor="fullName">Nombre completo *</Label>
        <Input
          id="fullName"
          value={data.fullName}
          onChange={(e) => onChange({ fullName: e.target.value })}
          placeholder="Ej: María García López"
        />
      </div>

      <div>
        <Label htmlFor="degree">Profesión / Título *</Label>
        <Input
          id="degree"
          value={data.degree}
          onChange={(e) => onChange({ degree: e.target.value })}
          placeholder="Ej: Desarrolladora Full Stack"
        />
      </div>

      <div>
        <Label htmlFor="email">Email</Label>
        <Input
          id="email"
          type="email"
          value={data.email}
          onChange={(e) => onChange({ email: e.target.value })}
          placeholder="tu@email.com"
        />
      </div>

      <div>
        <Label htmlFor="phone">Teléfono</Label>
        <Input
          id="phone"
          value={data.phone}
          onChange={(e) => onChange({ phone: e.target.value })}
          placeholder="+34 600 000 000"
        />
      </div>

      <div>
        <Label htmlFor="city">Ciudad / País</Label>
        <Input
          id="city"
          value={data.city}
          onChange={(e) => onChange({ city: e.target.value })}
          placeholder="Madrid, España"
        />
      </div>

      <div>
        <Label htmlFor="linkedin">LinkedIn (opcional)</Label>
        <Input
          id="linkedin"
          value={data.linkedin}
          onChange={(e) => onChange({ linkedin: e.target.value })}
          placeholder="linkedin.com/in/tu-perfil"
        />
      </div>

      <div>
        <Label htmlFor="github">GitHub / Portafolio (opcional)</Label>
        <Input
          id="github"
          value={data.github}
          onChange={(e) => onChange({ github: e.target.value })}
          placeholder="github.com/tu-usuario"
        />
      </div>
    </div>
  )
}
