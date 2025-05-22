# Gestión Coro Polifónico UPB Medellín

📘 Descripción General
Este proyecto consiste en el diseño de un sistema para gestionar las actividades y operaciones del Coro Polifónico de la Universidad Pontificia Bolivariana (UPB), sede Medellín, el cual está integrado por estudiantes, egresados, docentes y personal administrativo.

🎯 Objetivo
Facilitar el seguimiento de la participación, asistencia, repertorios interpretados y planificación de eventos mediante una plataforma web conectada a una base de datos.

🛠️ Funcionalidades Principales
Gestión de Integrantes
  • Registro detallado de cada miembro, incluyendo:
  • Gestión de Directores
  • Gestión de Ensayos
  • Lista de asistentes
  • Canciones
  • Gestión de Presentaciones
  • Registro completo de eventos
  • Repertorio interpretado

⚙️ Instrucciones de Instalación y Ejecución
Este sistema está desarrollado con ASP.NET Core (Razor Pages) y utiliza SQL Server como sistema de gestión de bases de datos.

📋 Requisitos Previos
  • SQL Server (versión 2017 o superior recomendada)
  • .NET SDK (ej. .NET 6, 7 u 8)
  • Visual Studio 2022 o Visual Studio Code
  • Base de datos CoroUPB configurada en tu instancia de SQL Server

🚀 Pasos para Ejecutar el Proyecto
Clonar o Descargar el Repositorio

	 git clone https://github.com/usuario/proyecto-coro-upb.git
 	 cd proyecto-coro-upb
  
Configurar la Base de Datos
Asegúrate de que la base de datos RequisitosUpb esté disponible en tu SQL Server.

Actualizar la Cadena de Conexión
Abre el archivo appsettings.json (o appsettings.Development.json) y modifica la cadena de conexión:

	"ConnectionStrings": {
  	 "DefaultConnection": "Server=TU_SERVIDOR;Database=RequisitosUpb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
	}

Reemplaza TU_SERVIDOR con el nombre de tu servidor SQL Server. Usa . si es una instancia local.

Restaurar los Paquetes NuGet
Desde Visual Studio: clic derecho sobre la solución → "Restaurar paquetes NuGet"

Acceder a la Aplicación Web
Abre tu navegador en la dirección que te proporcione Kestrel, por ejemplo:
https://localhost:5001/ o http://localhost:5000/

