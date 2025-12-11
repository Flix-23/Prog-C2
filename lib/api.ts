import axios from "axios"
import type { Resume, CreateResumeRequest } from "@/types"
import https from "https"

const api = axios.create({
  baseURL: process.env.NEXT_PUBLIC_API_URL || "http://localhost:5000/api",
  headers: {
    "Content-Type": "application/json",
  },
  httpsAgent: typeof window === "undefined" ? new https.Agent({ rejectUnauthorized: false }) : undefined,
})

// Resume endpoints
export const getCVs = async (): Promise<Resume[]> => {
  try {
    const response = await api.get<Resume[]>("/resume")
    return response.data
  } catch (error) {
    console.error("Error fetching CVs:", error)
    throw error
  }
}

export const getCVById = async (id: number): Promise<Resume> => {
  try {
    const response = await api.get<Resume>(`/resume/${id}`)
    return response.data
  } catch (error) {
    console.error("Error fetching CV by ID:", error)
    throw error
  }
}

export const createCV = async (data: CreateResumeRequest): Promise<Resume> => {
  try {
    const response = await api.post<Resume>("/resume", data)
    return response.data
  } catch (error: any) {
    console.error("Error creating CV - Full error:", {
      status: error.response?.status,
      statusText: error.response?.statusText,
      data: error.response?.data,
      message: error.message,
    })
    throw new Error(
      error.response?.data?.message || error.message || "Error al crear el CV"
    )
  }
}

export const updateCV = async (id: number, data: CreateResumeRequest): Promise<Resume> => {
  try {
    const response = await api.put<Resume>(`/resume/${id}`, data)
    return response.data
  } catch (error) {
    console.error("Error updating CV:", error)
    throw error
  }
}

export const deleteCV = async (id: number): Promise<void> => {
  try {
    await api.delete(`/resume/${id}`)
  } catch (error) {
    console.error("Error deleting CV:", error)
    throw error
  }
}

export const downloadCVPdf = async (id: number): Promise<Blob> => {
  try {
    const response = await api.get(`/resume/${id}/pdf`, {
      responseType: "blob",
    })
    return response.data
  } catch (error) {
    console.error("Error downloading CV PDF:", error)
    throw error
  }
}

export default api
