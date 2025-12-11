"use client"

import { Button } from "@/components/ui/button"
import { Input } from "@/components/ui/input"
import { Label } from "@/components/ui/label"
import { Card } from "@/components/ui/card"
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select"
import { PlusCircle, Trash2, X } from "lucide-react"
import type { CVData, Language, Project } from "@/types"
import { useState } from "react"

interface SkillsFormProps {
  data: CVData
  onChange: (data: Partial<CVData>) => void
}

export function SkillsForm({ data, onChange }: SkillsFormProps) {
  const [skillInput, setSkillInput] = useState("")
  const [softSkillInput, setSoftSkillInput] = useState("")

  const addSkill = () => {
    if (!skillInput.trim()) return
    onChange({
      skills: [...data.skills, { id: Date.now(), name: skillInput, level: 3 }],
    })
    setSkillInput("")
  }

  const updateSkill = (id: number, level: number) => {
    onChange({
      skills: data.skills.map((skill) => (skill.id === id ? { ...skill, level } : skill)),
    })
  }

  const removeSkill = (id: number) => {
    onChange({
      skills: data.skills.filter((skill) => skill.id !== id),
    })
  }

  const addLanguage = () => {
    onChange({
      languages: [...data.languages, { id: Date.now(), name: "", level: "Intermedio" }],
    })
  }

  const updateLanguage = (id: number, field: keyof Language, value: string) => {
    onChange({
      languages: data.languages.map((lang) => (lang.id === id ? { ...lang, [field]: value } : lang)),
    })
  }

  const removeLanguage = (id: number) => {
    onChange({
      languages: data.languages.filter((lang) => lang.id !== id),
    })
  }

  const addProject = () => {
    onChange({
      projects: [...data.projects, { id: Date.now(), name: "", description: "", technologies: "", link: "" }],
    })
  }

  const updateProject = (id: number, field: keyof Project, value: string) => {
    onChange({
      projects: data.projects.map((proj) => (proj.id === id ? { ...proj, [field]: value } : proj)),
    })
  }

  const removeProject = (id: number) => {
    onChange({
      projects: data.projects.filter((proj) => proj.id !== id),
    })
  }

  return (
    <div className="space-y-6">
      {/* Technical Skills */}
      <div className="space-y-3">
        <Label>Habilidades Técnicas</Label>
        <div className="flex gap-2">
          <Input
            placeholder="Ej: React, Python, SQL..."
            value={skillInput}
            onChange={(e) => setSkillInput(e.target.value)}
            onKeyPress={(e) => e.key === "Enter" && (e.preventDefault(), addSkill())}
          />
          <Button type="button" onClick={addSkill}>
            <PlusCircle className="h-4 w-4" />
          </Button>
        </div>
        <div className="flex flex-wrap gap-2">
          {data.skills.map((skill) => (
            <Card key={skill.id} className="px-3 py-2 flex items-center gap-2">
              <span className="text-sm">{skill.name}</span>
              <Select
                value={skill.level.toString()}
                onValueChange={(value) => updateSkill(skill.id, Number.parseInt(value))}
              >
                <SelectTrigger className="w-28 h-7 text-xs">
                  <SelectValue />
                </SelectTrigger>
                <SelectContent>
                  <SelectItem value="1">Básico</SelectItem>
                  <SelectItem value="2">Intermedio</SelectItem>
                  <SelectItem value="3">Avanzado</SelectItem>
                  <SelectItem value="4">Experto</SelectItem>
                </SelectContent>
              </Select>
              <Button type="button" variant="ghost" size="sm" onClick={() => removeSkill(skill.id)}>
                <X className="h-3 w-3" />
              </Button>
            </Card>
          ))}
        </div>
      </div>

      {/* Languages */}
      <div className="space-y-3">
        <div className="flex items-center justify-between">
          <Label>Idiomas</Label>
          <Button type="button" variant="outline" size="sm" onClick={addLanguage}>
            <PlusCircle className="h-4 w-4 mr-2" />
            Agregar
          </Button>
        </div>
        {data.languages.map((lang) => (
          <Card key={lang.id} className="p-3">
            <div className="flex gap-3 items-center">
              <Input
                placeholder="Idioma"
                value={lang.name}
                onChange={(e) => updateLanguage(lang.id, "name", e.target.value)}
              />
              <Select value={lang.level} onValueChange={(value) => updateLanguage(lang.id, "level", value)}>
                <SelectTrigger className="w-40">
                  <SelectValue />
                </SelectTrigger>
                <SelectContent>
                  <SelectItem value="Básico">Básico</SelectItem>
                  <SelectItem value="Intermedio">Intermedio</SelectItem>
                  <SelectItem value="Avanzado">Avanzado</SelectItem>
                  <SelectItem value="Nativo">Nativo</SelectItem>
                </SelectContent>
              </Select>
              <Button type="button" variant="ghost" size="sm" onClick={() => removeLanguage(lang.id)}>
                <Trash2 className="h-4 w-4" />
              </Button>
            </div>
          </Card>
        ))}
      </div>

      {/* Projects */}
      <div className="space-y-3">
        <div className="flex items-center justify-between">
          <Label>Proyectos</Label>
          <Button type="button" variant="outline" size="sm" onClick={addProject}>
            <PlusCircle className="h-4 w-4 mr-2" />
            Agregar
          </Button>
        </div>
        {data.projects.map((proj) => (
          <Card key={proj.id} className="p-4">
            <div className="space-y-3">
              <div className="flex justify-between items-start">
                <Label className="text-sm font-semibold">Proyecto</Label>
                <Button type="button" variant="ghost" size="sm" onClick={() => removeProject(proj.id)}>
                  <Trash2 className="h-4 w-4" />
                </Button>
              </div>
              <Input
                placeholder="Nombre del proyecto"
                value={proj.name}
                onChange={(e) => updateProject(proj.id, "name", e.target.value)}
              />
              <Input
                placeholder="Descripción"
                value={proj.description}
                onChange={(e) => updateProject(proj.id, "description", e.target.value)}
              />
              <Input
                placeholder="Tecnologías usadas"
                value={proj.technologies}
                onChange={(e) => updateProject(proj.id, "technologies", e.target.value)}
              />
              <Input
                placeholder="Enlace (opcional)"
                value={proj.link}
                onChange={(e) => updateProject(proj.id, "link", e.target.value)}
              />
            </div>
          </Card>
        ))}
      </div>
    </div>
  )
}
