# Patient API - Modern Cloud-Native Healthcare Integration

A production-ready RESTful API demonstrating modern .NET development practices with Docker containerization and Azure deployment.

## 🚀 Live Demo
**API:** https://patient-api-sornavel-2024.azurewebsites.net  
**Swagger UI:** https://patient-api-sornavel-2024.azurewebsites.net/swagger

Try it live! The API is accessible from anywhere in the world.

## 🛠️ Tech Stack
- **.NET 9** - Latest framework with minimal APIs
- **Docker** - Container orchestration
- **Azure Container Registry** - Private container image storage
- **Azure App Service (Linux)** - Cloud hosting platform
- **Swagger/OpenAPI** - Interactive API documentation
- **Application Insights** - Real-time monitoring and telemetry

## 📋 Features
- RESTful API with full CRUD operations
- In-memory data storage for patient records
- OpenAPI/Swagger documentation
- Fully containerized with Docker
- Cloud-native architecture
- Production monitoring with Azure Application Insights
- Healthcare domain focus (patient management)

## 🏗️ Architecture
```
Developer Workstation
    ↓
Docker Build (Dockerfile)
    ↓
Docker Image (patient-api:v1)
    ↓
Push to Azure Container Registry
    ↓
Azure App Service pulls and runs container
    ↓
Live API: https://patient-api-sornavel-2024.azurewebsites.net
    ↓
Monitored by Application Insights
```

### Infrastructure Components
- **Azure Container Registry**: Secure private registry for Docker images
- **Azure App Service (Linux B1)**: Hosts the containerized application
- **Application Insights**: Provides monitoring, logging, and analytics

## 🏃 Quick Start

### Prerequisites
- .NET 9 SDK
- Docker Desktop
- Azure CLI (for deployment)

### Run Locally (Without Docker)
```bash
dotnet restore
dotnet run

# Open http://localhost:5000/swagger
```

### Run with Docker
```bash
# Build Docker image
docker build -t patient-api .

# Run container
docker run -d -p 8080:8080 --name patient-api-container patient-api

# Open http://localhost:8080/swagger
```

### Deploy to Azure
```bash
# Login to Azure
az login

# Build and push to Azure Container Registry
az acr build --registry patientapiregistry --image patient-api:v1 .

# Deploy to App Service
az webapp config container set \
  --name patient-api-sornavel-2024 \
  --resource-group expensetracker-rg \
  --docker-custom-image-name patientapiregistry.azurecr.io/patient-api:v1
```

## 📊 API Endpoints

### Base URL
```
https://patient-api-sornavel-2024.azurewebsites.net
```

### Available Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/` | Health check - returns status message |
| GET | `/api/patients` | Retrieve all patients |
| GET | `/api/patients/{id}` | Retrieve specific patient by ID |
| POST | `/api/patients` | Create new patient record |

### Example Request (POST /api/patients)
```json
{
  "name": "John Doe",
  "age": 45,
  "condition": "Hypertension"
}
```

### Example Response
```json
{
  "id": 3,
  "name": "John Doe",
  "age": 45,
  "condition": "Hypertension"
}
```

## 🐳 Docker Configuration

### Dockerfile Highlights
- Multi-stage build for optimized image size
- Based on official Microsoft .NET 9 images
- Runs on port 8080
- Optimized for production deployment

### Image Details
- **Base Image**: `mcr.microsoft.com/dotnet/aspnet:9.0`
- **Build Image**: `mcr.microsoft.com/dotnet/sdk:9.0`
- **Final Size**: ~220MB
- **Registry**: `patientapiregistry.azurecr.io`

## ☁️ Azure Deployment

### Resources Used
- **Resource Group**: `expensetracker-rg`
- **Container Registry**: `patientapiregistry` (Basic SKU)
- **App Service Plan**: `PatientAPI-Linux-Plan` (B1 tier, Linux)
- **Web App**: `patient-api-sornavel-2024`
- **Region**: Central India

### Deployment Workflow
1. Code committed to GitHub
2. Docker image built locally
3. Image pushed to Azure Container Registry
4. App Service pulls latest image
5. Container deployed and running
6. Application Insights monitors health

## 📈 Monitoring

### Application Insights Metrics
- Request rates and response times
- Failure rates and exceptions
- Geographic distribution of users
- Custom telemetry and events

### View Logs
```bash
az webapp log tail --name patient-api-sornavel-2024 --resource-group expensetracker-rg
```

## 👨‍💻 About This Project

Built as part of a modern .NET skill upgrade journey, demonstrating:
- Transition from legacy .NET to modern cloud-native development
- 13 years of software development experience
- Healthcare domain expertise (Lorenzo EPR, SmartCare EHR)
- Focus on FHIR standards and healthcare integrations

### Professional Background
- **Experience**: 13 years in software development
- **Domain**: Healthcare IT (EPR/EHR systems)
- **Previous Systems**: Lorenzo EPR (Dedalus), SmartCare EHR (Streamline Healthcare)
- **Current Focus**: Cloud-native microservices, FHIR integration, Azure platform

## 🗺️ Roadmap

- [x] Basic REST API with minimal APIs
- [x] Docker containerization
- [x] GitHub repository setup
- [x] Azure Container Registry integration
- [x] Azure App Service deployment
- [x] Application Insights monitoring
- [ ] CI/CD pipeline with GitHub Actions
- [ ] Database integration (Azure SQL)
- [ ] Authentication & Authorization (JWT)
- [ ] FHIR-compliant endpoints
- [ ] Unit and integration tests
- [ ] Microservices architecture (Appointments service)
- [ ] API Gateway implementation
- [ ] Message queue integration (Azure Service Bus)

## 🔧 Development

### Project Structure
```
PatientAPI/
├── Program.cs              # Main application entry point
├── PatientAPI.csproj       # Project configuration
├── Dockerfile              # Container build instructions
├── .gitignore             # Git ignore rules
└── README.md              # This file
```

### Technologies & Patterns
- **Minimal APIs**: Lightweight, performant routing
- **Dependency Injection**: Built-in .NET DI container
- **In-Memory Storage**: Simple data persistence for demo
- **Swagger Integration**: Auto-generated API documentation
- **Multi-stage Docker Build**: Optimized container images

## 📞 Contact

- **GitHub**: https://github.com/YOUR_USERNAME/patient-api-cloud
- **LinkedIn**: [Your LinkedIn Profile]
- **Email**: ksornavel@gmail.com

## 📝 License

This project is for educational and portfolio purposes.

---

**Built with ❤️ using .NET 9, Docker, and Azure**

*Demonstrating modern cloud-native development practices for healthcare integrations*