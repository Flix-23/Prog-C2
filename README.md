# CvAlInstante - Sistema de Generación de Currículums

Sistema full-stack para crear, editar y gestionar currículums vitae de forma rápida e instantánea. Permite a los usuarios generar CVs profesionales con una interfaz intuitiva y almacenarlos en una base de datos centralizada.

## Stack Tecnológico

### Backend (C# / .NET)
- ASP.NET Core Web API (.NET 8)
- Entity Framework Core 8
- Microsoft SQL Server
- Clean Architecture (Domain, Application, Infrastructure, API layers)
- Windows Authentication

### Frontend (Next.js / React)
- Next.js 15.5.7 (App Router)
- React 19
- TypeScript
- Tailwind CSS
- shadcn/ui Component Library
- Axios for API Communication

## Instalación Rápida

### Prerequisitos

- .NET 8 SDK o superior
- SQL Server (LocalDB, SQL Server Express, o servidor remoto)
- Node.js 18+ con npm
- Git

### Pasos de Instalación

1. **Clonar el repositorio**
   ```bash
   git clone <repositorio>
   cd CvAlInstante
   ```

2. **Configurar la base de datos**

   Edita `CvAlInstante.API/appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=TU_SERVIDOR;Database=CvAlInstanteDb;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
     }
   }
   ```

3. **Aplicar migraciones (si es necesario)**
   ```bash
   cd CvAlInstante.Infrastructure
   dotnet ef database update --context CvDbContext --startup-project ..\CvAlInstante.API
   ```

4. **Instalar dependencias del frontend**
   ```bash
   npm install
   ```

5. **Crear archivo `.env.local`** en la raíz del proyecto:
   ```env
   NEXT_PUBLIC_API_URL=http://127.0.0.1:5000/api
   ```

## Ejecutar en Desarrollo

**Terminal 1 - Backend:**
```bash
cd CvAlInstante.API
dotnet run --no-launch-profile
```
Backend disponible en: `http://localhost:5000`

**Terminal 2 - Frontend:**
```bash
npm run dev
```
Frontend disponible en: `http://localhost:3000`

## Estructura del Proyecto

### Backend (.NET)

```
CvAlInstante.API/            # ASP.NET Core API & Controllers
CvAlInstante.Application/    # Business Logic & Services
CvAlInstante.Domain/         # Entity Models & Interfaces
CvAlInstante.Infrastructure/ # Data Access & Repositories
```

### Frontend (Next.js)

```
app/
├── page.tsx                 # Landing page
├── dashboard/page.tsx       # CV Dashboard
├── cv/nuevo/page.tsx        # CV Wizard
├── cv/[id]/editar/page.tsx  # CV Editor
└── plantillas/page.tsx      # Templates

components/
├── forms/                   # Form components by section
├── ui/                      # shadcn UI components
├── cv-wizard.tsx            # Multi-step wizard
├── cv-preview.tsx           # CV preview
└── dashboard-layout.tsx     # Layout wrapper

lib/
├── api.ts                  # Axios API client
└── utils.ts                # Utility functions

types/index.ts              # TypeScript interfaces
```

## Características Principales

✅ **Crear currículums** con wizard paso a paso  
✅ **Editar** información personal, educación y experiencia  
✅ **Agregar habilidades** técnicas  
✅ **Vista previa** en tiempo real  
✅ **Persistencia** en SQL Server  
✅ **API RESTful** documentada  
✅ **Interfaz responsiva** con Tailwind CSS  
✅ **Componentes reutilizables** con shadcn/ui  

## API Endpoints

### Resumes
- `GET /api/resume` - Lista todos los CVs
- `GET /api/resume/{id}` - Obtiene un CV por ID
- `POST /api/resume` - Crea un nuevo CV
- `PUT /api/resume/{id}` - Actualiza un CV
- `DELETE /api/resume/{id}` - Elimina un CV

### Education
- `GET /api/educationrecord/resume/{resumeId}` - Educación por CV
- `POST /api/educationrecord` - Agrega educación

### Work Experience
- `GET /api/workexperience/resume/{resumeId}` - Experiencia por CV
- `POST /api/workexperience` - Agrega experiencia

### Skills
- `GET /api/skill/resume/{resumeId}` - Habilidades por CV
- `POST /api/skill` - Agrega habilidad

## Problemas Comunes

### Error de CORS
- Verifica que el frontend esté en `http://localhost:3000`
- Revisa la configuración de CORS en `CvAlInstante.API/Program.cs`

### Error de conexión a la base de datos
- Verifica que SQL Server esté ejecutándose
- Confirma la cadena de conexión en `appsettings.json`
- Asegúrate de haber ejecutado las migraciones

### Puerto en uso
- Backend (5000): `netstat -ano | findstr :5000` (Windows)
- Frontend (3000): `netstat -ano | findstr :3000` (Windows)

## Build para Producción

### Frontend
```bash
npm run build
npm start
```

### Backend
```bash
cd CvAlInstante.API
dotnet publish -c Release
```

## Contribución

Las contribuciones son bienvenidas. Por favor, abre un issue o pull request.

