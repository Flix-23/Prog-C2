export interface Resume {
  id: number
  fullName: string
  degree: string
  professionalSummary: string
  email: string
  phone: string
  location: string
  linkedin: string
  portfolio: string
  educationRecords: EducationRecord[]
  workExperiences: WorkExperience[]
  skills: Skill[]
}

export interface CreateResumeRequest {
  fullName: string
  degree: string
  professionalSummary?: string
  email?: string
  phone?: string
  location?: string
  linkedin?: string
  portfolio?: string
  educationRecords?: EducationRecord[]
  workExperiences?: WorkExperience[]
  skills?: Skill[]
}

export interface EducationRecord {
  id?: number
  title: string
  institution: string
  startDate: string
  endDate?: string
  resumeId?: number
}

export interface WorkExperience {
  id?: number
  role: string
  company: string
  description: string
  achievements?: string
  startDate: string
  endDate?: string
  resumeId?: number
}

export interface Skill {
  id?: number
  name: string
  level: number
  resumeId?: number
}

export interface Language {
  id: number
  name: string
  level: string
}

export interface Project {
  id: number
  name: string
  description: string
  technologies: string
  link: string
}

export interface CVData {
  fullName: string
  degree: string
  professionalSummary: string
  email: string
  phone: string
  city: string
  linkedin: string
  github: string
  education: EducationRecord[]
  experience: WorkExperience[]
  skills: Skill[]
  languages: Language[]
  projects: Project[]
}
