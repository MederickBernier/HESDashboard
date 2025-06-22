# HESDashboard 🩺  
**A Health Engineering System built in ASP.NET Core for personal health tracking.**  
**Un système de santé structuré développé en ASP.NET Core pour le suivi personnel.**

---

## 🇺🇸 English Version

### 💡 Project Overview

**HESDashboard** is a modular ASP.NET Core MVC web application for structured health management. It allows tracking of personal health metrics (e.g., weight, body composition), medication usage, and future planning — with a focus on long-term visibility, control, and accountability.

Built by an engineer for engineers — fully offline-capable, secure, and optimized for solo use or closed environments.

---

### 🧱 Features

#### 📊 Health Metrics
- Log daily data points:
  - Weight, BMI, Body Fat %, Muscle Mass, etc.
- Phase tracking to follow health journey over time
- Editable, timestamped entries

#### 💊 Medication System
- **Medication Catalog (Admin only)**
  - Define medications with names, default dosage, notes, and usual food pairing
- **Medication Entry (User)**
  - Log what was taken, when, and how
  - Override default dosage, track with/without food
  - Notes field for custom details

#### 🔐 Architecture & UX
- ViewModels used for clean form handling
- Fully service-based (e.g., `IMedicationService`)
- Razor Pages with Bootstrap 5
- No JavaScript frameworks, no third-party cloud dependencies

---

### 🔧 Tech Stack

- ASP.NET Core MVC (.NET 8)
- C# 12
- Razor Views + ViewModels
- Bootstrap 5
- Service-based separation (Dependency Injection ready)

---

### 🚀 Getting Started

#### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- Visual Studio 2022+ or VS Code

#### Run the App

```bash
git clone https://github.com/MederickBernier/HESDashboard.git
cd HESDashboard
dotnet run
```

Visit: `https://localhost:5001`

---

### 🗺️ Roadmap

- ✅ Health Metrics Logging
- ✅ Medication Catalog & Intake Logging
- 🔜 Smart Alert System (missed meals, HR, medication)
- 🔜 Trend Forecasting Engine (EMA, Holt-Winters, ARIMA)
- 🔜 PDF Report Generator
- 🔜 Export to CSV / JSON / PDF
- 🔜 Authentication (Admin / User)
- 🔜 API for external integration

---

### 🧠 Philosophy

HESDashboard is built to **bring structure to health** like an engineer brings to code — with traceability, control, and precision. It respects privacy and autonomy without sacrificing usability.

---

### 🤝 Contributing

This is a personal system. You are free to fork and modify for your own use. Contributions may be considered in the future once the architecture is fully stable.

---

### 📜 License

MIT License

---

### 👤 Author

**Mederick Bernier**  
📍 Quebec, Canada  
🔧 Legacy modernization, system engineering, and tooling architect.

---

## 🇫🇷 Version Française

### 💡 Présentation du projet

**HESDashboard** est une application web modulaire en ASP.NET Core MVC conçue pour la gestion personnelle de la santé. Elle permet le suivi quotidien de métriques santé (poids, masse graisseuse, etc.), des prises de médicaments et des phases de progression.

Pensé pour un usage personnel ou dans un environnement local sécurisé.

---

### 🧱 Fonctionnalités

#### 📊 Suivi Santé
- Enregistrement des données quotidiennes :
  - Poids, IMC, % graisse corporelle, masse musculaire, etc.
- Système de **phases** pour structurer les objectifs santé
- Édition possible des données avec horodatage

#### 💊 Système Médicamenteux
- **Catalogue Médicaments (Admin)**
  - Ajouter des médicaments avec dosage par défaut, notes, prise avec/​sans nourriture
- **Entrée Médicamenteuse (Utilisateur)**
  - Journaliser les prises réelles
  - Saisir un dosage personnalisé si différent du défaut
  - Champ de notes pour ajouter des précisions

#### 🔐 Architecture & Interface
- Utilisation de **ViewModels** pour des formulaires robustes
- Architecture en **services injectés** (`IMedicationService`, etc.)
- Razor Pages avec Bootstrap 5
- Aucune dépendance cloud ou JavaScript externe

---

### 🔧 Technologies utilisées

- ASP.NET Core MVC (.NET 8)
- C# 12
- Razor + ViewModels
- Bootstrap 5
- Injection de dépendances

---

### 🚀 Démarrage rapide

#### Prérequis
- [.NET 8 SDK](https://dotnet.microsoft.com/fr-fr/download)
- Visual Studio 2022+ ou Visual Studio Code

#### Lancer l’application

```bash
git clone https://github.com/MederickBernier/HESDashboard.git
cd HESDashboard
dotnet run
```

Accéder à l'application : `https://localhost:5001`

---

### 🗺️ Feuille de route

- ✅ Journal de santé quotidien
- ✅ Système de médicaments complet (Admin + Utilisateur)
- 🔜 Système d’alertes intelligentes (repas/médicament manqué, rythme cardiaque)
- 🔜 Moteur de prévision (EMA, Holt-Winters, ARIMA)
- 🔜 Générateur de rapport PDF
- 🔜 Export CSV / JSON / PDF
- 🔜 Authentification simple (Admin / Utilisateur)
- 🔜 API d’intégration externe

---

### 🧠 Philosophie

HESDashboard vise à ramener **structure et discipline dans la gestion personnelle de la santé**, à la manière d’un système technique : fiable, précis, et documenté.

---

### 🤝 Contribuer

Le projet est personnel mais libre d'utilisation en fork. Les contributions publiques seront envisagées plus tard une fois l’architecture stabilisée.

---

### 📜 Licence

Licence MIT

---

### 👤 Auteur

**Mederick Bernier**  
📍 Québec, Canada  
🔧 Ingénierie logicielle, modernisation des systèmes legacy, architecture d’outils personnalisés.
