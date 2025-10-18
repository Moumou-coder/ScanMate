# ScanMate

**ScanMate** est une application de gestion de personnages basée sur l’univers de **League of Legends (LoL)**. Développée en **C# avec .NET MAUI**, elle permet d’identifier et gérer des personnages via la **lecture de codes-barres**. Ce projet a été réalisé dans le cadre d’un projet académique durant l’année **2022–2023**.

---

## 🧭 Table des matières

- [Introduction](#introduction)
- [Fonctionnalités](#fonctionnalités)
- [Technologies utilisées](#technologies-utilisées)
- [Installation](#installation)
- [Utilisation](#utilisation)
- [Configuration requise](#configuration-requise)
- [Remarques importantes](#remarques-importantes)
- [Contributeurs](#contributeurs)
- [Licence](#licence)

---

## 🧩 Introduction

ScanMate est un **logiciel de gestion d’objets et de personnages** fonctionnant via un scanner de code-barres externe. Il s'appuie sur une interface intuitive et permet d’identifier les entités grâce à des standards de codes largement utilisés (UPC, EAN, QR Code, DataMatrix, AZTEC).

---

## ✨ Fonctionnalités

- 📷 **Reconnaissance de personnes** via lecture de code-barres
- 🗃️ **CRUD complet** (Créer, Lire, Mettre à jour, Supprimer) des personnages de LoL
- 🔌 **Connexion à une base de données locale**
- 🔍 Lecture de divers formats : UPC, EAN, QR Code, Datamatrix, AZTEC
- 🖥️ Interface utilisateur basée sur .NET MAUI

---

## 🧪 Technologies utilisées

- **Langage** : C#
- **Framework** : [.NET MAUI](https://learn.microsoft.com/en-us/dotnet/maui/)
- **Base de données** : locale (via ScanMateServer)
- **Périphérique** : lecteur de code-barres compatible type **M900D**
- **IDE recommandé** : [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)

---

## 🛠️ Installation

1. Cloner le dépôt ou récupérer les fichiers sources du projet
2. Ouvrir le projet dans **Visual Studio 2022**
3. Restaurer les packages NuGet si nécessaire
4. Compiler et exécuter le projet

---

## 🚀 Utilisation

1. Démarrer l’application **ScanMate**
2. S’assurer que le serveur **ScanMateServer** est bien placé sur le **bureau**
3. Brancher le **scanner de code-barres** (type M900D)
4. Scanner un code associé à un personnage pour accéder à sa fiche
5. Gérer les données via les options CRUD

---

## ⚙️ Configuration requise

- Windows 10 ou supérieur
- Visual Studio 2022 avec .NET MAUI installé
- Connexion à une base de données locale via le serveur **ScanMateServer**
- Scanner de code-barres USB (compatible)

---

## ❗ Remarques importantes

> 📌 **Le serveur `ScanMateServer` doit impérativement être placé sur le bureau** pour que l’application puisse se connecter à la base de données.

> ⚠️ L’application nécessite un **scanner de code-barres externe** pour fonctionner correctement.

---

## 👥 Contributeurs

- Projet développé dans le cadre d’un cursus académique 2022–2023  

---

## 📄 Licence

**Licence : Usage académique uniquement.**

---
