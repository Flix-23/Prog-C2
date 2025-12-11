"use client"

import { DashboardLayout } from "@/components/dashboard-layout"
import { Card } from "@/components/ui/card"
import { Label } from "@/components/ui/label"
import { Input } from "@/components/ui/input"
import { Button } from "@/components/ui/button"
import { Switch } from "@/components/ui/switch"
import { Separator } from "@/components/ui/separator"
import { Save, User, Bell, Lock, Palette } from "lucide-react"

export default function ConfiguracionPage() {
  return (
    <DashboardLayout>
      <div className="space-y-6">
        <div>
          <h1 className="text-3xl font-bold">Configuración</h1>
          <p className="text-muted-foreground mt-1">Personaliza tu experiencia en CvAlInstante</p>
        </div>

        <div className="grid gap-6">
          {/* Perfil */}
          <Card className="p-6">
            <div className="flex items-center gap-2 mb-4">
              <User className="h-5 w-5 text-primary" />
              <h2 className="text-xl font-semibold">Información de Perfil</h2>
            </div>
            <div className="space-y-4">
              <div>
                <Label htmlFor="name">Nombre completo</Label>
                <Input id="name" placeholder="Tu nombre" />
              </div>
              <div>
                <Label htmlFor="email">Email</Label>
                <Input id="email" type="email" placeholder="tu@email.com" />
              </div>
              <Button>
                <Save className="h-4 w-4 mr-2" />
                Guardar cambios
              </Button>
            </div>
          </Card>

          {/* Notificaciones */}
          <Card className="p-6">
            <div className="flex items-center gap-2 mb-4">
              <Bell className="h-5 w-5 text-primary" />
              <h2 className="text-xl font-semibold">Notificaciones</h2>
            </div>
            <div className="space-y-4">
              <div className="flex items-center justify-between">
                <div className="space-y-0.5">
                  <Label>Notificaciones por email</Label>
                  <p className="text-sm text-muted-foreground">Recibe actualizaciones sobre tus CVs</p>
                </div>
                <Switch />
              </div>
              <Separator />
              <div className="flex items-center justify-between">
                <div className="space-y-0.5">
                  <Label>Recordatorios de actualización</Label>
                  <p className="text-sm text-muted-foreground">Te recordamos actualizar tu CV mensualmente</p>
                </div>
                <Switch />
              </div>
            </div>
          </Card>

          {/* Seguridad */}
          <Card className="p-6">
            <div className="flex items-center gap-2 mb-4">
              <Lock className="h-5 w-5 text-primary" />
              <h2 className="text-xl font-semibold">Seguridad</h2>
            </div>
            <div className="space-y-4">
              <div>
                <Label htmlFor="current-password">Contraseña actual</Label>
                <Input id="current-password" type="password" />
              </div>
              <div>
                <Label htmlFor="new-password">Nueva contraseña</Label>
                <Input id="new-password" type="password" />
              </div>
              <div>
                <Label htmlFor="confirm-password">Confirmar contraseña</Label>
                <Input id="confirm-password" type="password" />
              </div>
              <Button variant="secondary">Cambiar contraseña</Button>
            </div>
          </Card>

          {/* Apariencia */}
          <Card className="p-6">
            <div className="flex items-center gap-2 mb-4">
              <Palette className="h-5 w-5 text-primary" />
              <h2 className="text-xl font-semibold">Apariencia</h2>
            </div>
            <div className="space-y-4">
              <div className="flex items-center justify-between">
                <div className="space-y-0.5">
                  <Label>Modo oscuro</Label>
                  <p className="text-sm text-muted-foreground">Cambia entre tema claro y oscuro</p>
                </div>
                <Switch />
              </div>
            </div>
          </Card>
        </div>
      </div>
    </DashboardLayout>
  )
}
