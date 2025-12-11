import { Card } from "@/components/ui/card"
import type { CVData } from "@/types"
import { Mail, Phone, MapPin, Linkedin, Github, Calendar } from "lucide-react"

interface CVPreviewProps {
  data: CVData
}

export function CVPreview({ data }: CVPreviewProps) {
  return (
    <Card className="p-8 bg-white text-gray-900">
      <div className="space-y-6">
        {/* Header */}
        <div className="border-b border-gray-200 pb-6">
          <h1 className="text-3xl font-bold text-gray-900">{data.fullName || "Tu Nombre"}</h1>
          <p className="text-lg text-gray-600 mt-1">{data.degree || "Tu Profesión"}</p>
          <div className="flex flex-wrap gap-4 mt-3 text-sm text-gray-600">
            {data.email && (
              <div className="flex items-center gap-1">
                <Mail className="h-3 w-3" />
                <span>{data.email}</span>
              </div>
            )}
            {data.phone && (
              <div className="flex items-center gap-1">
                <Phone className="h-3 w-3" />
                <span>{data.phone}</span>
              </div>
            )}
            {data.city && (
              <div className="flex items-center gap-1">
                <MapPin className="h-3 w-3" />
                <span>{data.city}</span>
              </div>
            )}
          </div>
          {(data.linkedin || data.github) && (
            <div className="flex gap-4 mt-2 text-sm">
              {data.linkedin && (
                <a href={`https://${data.linkedin}`} className="flex items-center gap-1 text-blue-600 hover:underline">
                  <Linkedin className="h-3 w-3" />
                  <span>LinkedIn</span>
                </a>
              )}
              {data.github && (
                <a href={`https://${data.github}`} className="flex items-center gap-1 text-blue-600 hover:underline">
                  <Github className="h-3 w-3" />
                  <span>GitHub</span>
                </a>
              )}
            </div>
          )}
        </div>

        {/* Professional Summary */}
        {data.professionalSummary && (
          <div>
            <h2 className="text-lg font-semibold text-gray-900 mb-2">Perfil Profesional</h2>
            <p className="text-sm text-gray-700 leading-relaxed">{data.professionalSummary}</p>
          </div>
        )}

        {/* Experience */}
        {data.experience.length > 0 && (
          <div>
            <h2 className="text-lg font-semibold text-gray-900 mb-3">Experiencia Laboral</h2>
            <div className="space-y-4">
              {data.experience.map((exp) => (
                <div key={exp.id}>
                  <div className="flex justify-between items-start">
                    <div>
                      <h3 className="font-semibold text-gray-900">{exp.role || "Puesto"}</h3>
                      <p className="text-sm text-gray-600">{exp.company || "Empresa"}</p>
                    </div>
                    {(exp.startDate || exp.endDate) && (
                      <span className="text-xs text-gray-500 flex items-center gap-1">
                        <Calendar className="h-3 w-3" />
                        {exp.startDate} - {exp.endDate}
                      </span>
                    )}
                  </div>
                  {exp.description && <p className="text-sm text-gray-700 mt-1">{exp.description}</p>}
                  {exp.achievements && <p className="text-sm text-gray-600 mt-1 italic">{exp.achievements}</p>}
                </div>
              ))}
            </div>
          </div>
        )}

        {/* Education */}
        {data.education.length > 0 && (
          <div>
            <h2 className="text-lg font-semibold text-gray-900 mb-3">Formación Académica</h2>
            <div className="space-y-3">
              {data.education.map((edu) => (
                <div key={edu.id}>
                  <div className="flex justify-between items-start">
                    <div>
                      <h3 className="font-semibold text-gray-900">{edu.title || "Título"}</h3>
                      <p className="text-sm text-gray-600">{edu.institution || "Institución"}</p>
                    </div>
                    {(edu.startDate || edu.endDate) && (
                      <span className="text-xs text-gray-500">
                        {edu.startDate} - {edu.endDate}
                      </span>
                    )}
                  </div>
                  {edu.description && <p className="text-sm text-gray-700 mt-1">{edu.description}</p>}
                </div>
              ))}
            </div>
          </div>
        )}

        {/* Skills */}
        {data.skills.length > 0 && (
          <div>
            <h2 className="text-lg font-semibold text-gray-900 mb-2">Habilidades Técnicas</h2>
            <div className="flex flex-wrap gap-2">
              {data.skills.map((skill) => (
                <span key={skill.id} className="px-3 py-1 bg-gray-100 text-gray-800 text-sm rounded-full">
                  {skill.name}
                </span>
              ))}
            </div>
          </div>
        )}

        {/* Languages */}
        {data.languages.length > 0 && (
          <div>
            <h2 className="text-lg font-semibold text-gray-900 mb-2">Idiomas</h2>
            <div className="grid grid-cols-2 gap-2">
              {data.languages.map((lang) => (
                <div key={lang.id} className="text-sm">
                  <span className="font-medium text-gray-900">{lang.name}:</span>{" "}
                  <span className="text-gray-600">{lang.level}</span>
                </div>
              ))}
            </div>
          </div>
        )}

        {/* Projects */}
        {data.projects.length > 0 && (
          <div>
            <h2 className="text-lg font-semibold text-gray-900 mb-3">Proyectos</h2>
            <div className="space-y-3">
              {data.projects.map((proj) => (
                <div key={proj.id}>
                  <h3 className="font-semibold text-gray-900">{proj.name || "Proyecto"}</h3>
                  {proj.description && <p className="text-sm text-gray-700 mt-1">{proj.description}</p>}
                  {proj.technologies && <p className="text-xs text-gray-600 mt-1">Tecnologías: {proj.technologies}</p>}
                  {proj.link && (
                    <a href={proj.link} className="text-xs text-blue-600 hover:underline mt-1 inline-block">
                      Ver proyecto
                    </a>
                  )}
                </div>
              ))}
            </div>
          </div>
        )}
      </div>
    </Card>
  )
}
