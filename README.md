# 🔐 Token_JWT - Authentification et Gestion des JWT avec WPF

[![Language](https://img.shields.io/badge/Language-C%23-239120?style=flat-square&logo=csharp)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Framework](https://img.shields.io/badge/Framework-WPF-0078D4?style=flat-square&logo=microsoft)](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/)
[![License](https://img.shields.io/badge/License-MIT-green?style=flat-square)](LICENSE)

## 📋 Description

Projet C# complet démontrant l'utilisation et la maîtrise du framework **WPF** (Windows Presentation Foundation) pour construire une application d'authentification robuste et sécurisée. Ce projet couvre la gestion complète des **JSON Web Tokens (JWT)** pour l'authentification Backend ainsi que les meilleures pratiques de sécurité moderne.

## ✨ Fonctionnalités Principales

- 🔑 **Authentification par JWT** - Implémentation complète des JSON Web Tokens
- 🎯 **Interface WPF** - Création d'interfaces utilisateur modernes et réactives
- 🔒 **Sécurité** - Gestion sécurisée des tokens et des credentials
- 📡 **Communication API** - Intégration avec des services Backend
- 🏗️ **Architecture Clean** - Patterns de conception professionnels (MVVM, Repository Pattern, etc.)
- 🛡️ **Authentification & Autorisation** - Gestion des rôles et permissions
- 💾 **Stockage Sécurisé** - Conservation sécurisée des tokens

## 🎯 Objectifs du Projet

Ce projet a été créé pour maîtriser :

1. **Les Fondamentaux de WPF**
   - Binding de données (XAML)
   - Contrôles et composants
   - Gestion des événements
   - Styles et Templates

2. **La Gestion des Tokens JWT**
   - Création et validation de tokens
   - Claims et permissions
   - Renouvellement de tokens (refresh token)
   - Authentification Bearer

3. **Communication avec une API Backend**
   - Requêtes HTTP (HttpClient)
   - Sérialisation/Désérialisation JSON
   - Gestion des erreurs réseau
   - Gestion des timeouts

4. **La Sécurité**
   - Stockage des credentials
   - Hachage et chiffrement
   - Protection contre les vulnérabilités courantes
   - Gestion des sessions

## 🚀 Démarrage Rapide

### Prérequis

- **.NET Framework** 4.7.2 ou supérieur (ou .NET Core 3.1+)
- **Visual Studio** 2019 ou supérieur
- **NuGet** pour la gestion des dépendances

### Installation

1. **Cloner le repository**
```bash
git clone https://github.com/ast116/Token_JWT.git
cd Token_JWT
```

2. **Restaurer les dépendances NuGet**
```bash
dotnet restore
```

3. **Ouvrir la solution**
```bash
# Avec Visual Studio
start Token_JWT.sln

# Ou avec Visual Studio Code
code .
```

4. **Compiler et exécuter**
```bash
dotnet build
dotnet run
```

## 📁 Structure du Projet

```
Token_JWT/
├── 📂 Models/                      # Classes de données
│   ├── User.cs                     # Modèle utilisateur
│   ├── LoginRequest.cs             # Requête de connexion
│   └── TokenResponse.cs            # Réponse avec token
│
├── 📂 Services/                    # Couche métier
│   ├── AuthenticationService.cs    # Service d'authentification
│   ├── TokenService.cs             # Gestion des tokens JWT
│   ├── ApiService.cs               # Communication API
│   └── StorageService.cs           # Stockage sécurisé
│
├── 📂 Views/                       # Interfaces WPF
│   ├── LoginWindow.xaml            # Fenêtre de connexion
│   ├── DashboardWindow.xaml        # Tableau de bord
│   └── SettingsWindow.xaml         # Paramètres
│
├── 📂 ViewModels/                  # Logique de présentation (MVVM)
│   ├── LoginViewModel.cs           # ViewModel de connexion
│   ├── DashboardViewModel.cs       # ViewModel tableau de bord
│   └── BaseViewModel.cs            # ViewModel de base
│
├── 📂 Utilities/                   # Utilitaires
│   ├── EncryptionHelper.cs         # Chiffrement
│   ├── JwtHelper.cs                # Utilitaires JWT
│   └── Constants.cs                # Constantes
│
├── App.xaml                        # Configuration application
├── App.xaml.cs                     # Code-behind application
└── README.md                       # Ce fichier
```

## 🔑 Concepts Clés

### JWT (JSON Web Token)

Un JWT est composé de 3 parties séparées par des points (`.`) :

```
eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIn0.dozjgNryP4J3jVmNHl0w5N_XgL0n3I9PlFUP0THsR8U
  ↑ Header                          ↑ Payload                  ↑ Signature
```

- **Header** : Type de token et algorithme
- **Payload** : Données utilisateur (claims)
- **Signature** : Vérification de l'authenticité

### Architecture MVVM

Le pattern Model-View-ViewModel est utilisé pour une séparation des responsabilités :

```
┌─────────────────────────────────────────┐
│            Vue (XAML/WPF)               │
│        (Affichage des données)          │
└─────────────┬───────────────────────────┘
              │ Binding
┌─────────────▼───────────────────────────┐
│        ViewModel (C#)                    │
│    (Logique de présentation)             │
└─────────────┬───────────────────────────┘
              │ Appel
┌─────────────▼───────────────────────────┐
│         Model (C#)                       │
│      (Données & Métier)                  │
└─────────────────────────────────────────┘
```

## 🔐 Flux d'Authentification

```
1. Utilisateur saisit identifiants
        ↓
2. WPF envoie LoginRequest à l'API Backend
        ↓
3. Backend valide les identifiants
        ↓
4. Backend génère JWT (Access Token + Refresh Token)
        ↓
5. WPF reçoit et stocke les tokens de manière sécurisée
        ↓
6. Pour les requêtes suivantes :
   - Ajouter le JWT dans le header "Authorization: Bearer <token>"
        ↓
7. Si le token expire, utiliser le Refresh Token
```

## 📦 Dépendances Principales

Les packages NuGet recommandés pour ce projet :

```xml
<!-- JWT -->
<PackageReference Include="System.IdentityModel.Tokens.Jwt" Version="6.x.x" />

<!-- Communication HTTP -->
<PackageReference Include="HttpClientFactory" Version="x.x.x" />

<!-- Sérialisation JSON -->
<PackageReference Include="Newtonsoft.Json" Version="13.x.x" />

<!-- Chiffrement -->
<PackageReference Include="System.Security.Cryptography.Xml" Version="x.x.x" />

<!-- Logging -->
<PackageReference Include="NLog" Version="5.x.x" />
```

## 💡 Exemples d'Utilisation

### Connexion Utilisateur

```csharp
// Dans LoginViewModel
private async void Login()
{
    try
    {
        var loginRequest = new LoginRequest 
        { 
            Username = Username, 
            Password = Password 
        };
        
        var response = await _authService.LoginAsync(loginRequest);
        
        if (response.Success)
        {
            // Token stocké de manière sécurisée
            _tokenService.SaveToken(response.AccessToken);
            NavigateToDashboard();
        }
    }
    catch (Exception ex)
    {
        ErrorMessage = "Erreur lors de la connexion";
        Logger.Error(ex);
    }
}
```

### Appel API Sécurisé

```csharp
// Dans ApiService
public async Task<T> GetAsync<T>(string endpoint)
{
    var token = _tokenService.GetToken();
    
    using (var request = new HttpRequestMessage(HttpMethod.Get, endpoint))
    {
        request.Headers.Authorization = 
            new AuthenticationHeaderValue("Bearer", token);
        
        var response = await _httpClient.SendAsync(request);
        
        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        {
            await RefreshTokenAsync();
            return await GetAsync<T>(endpoint); // Retry
        }
        
        return await response.Content.ReadAsAsync<T>();
    }
}
```

## 🛡️ Bonnes Pratiques de Sécurité

- ✅ **Ne jamais** stocker les mots de passe en texte clair
- ✅ Utiliser HTTPS pour toutes les communications
- ✅ Stocker les tokens dans un endroit sécurisé (Credential Manager)
- ✅ Implémenter le CORS correctement sur le Backend
- ✅ Valider et nettoyer les entrées utilisateur
- ✅ Utiliser des connexions sécurisées avec certificats
- ✅ Implémenter un système de logs pour l'audit

## 🧪 Tests

### Exécuter les tests unitaires

```bash
dotnet test
```

### Tester l'API Backend

Vous pouvez utiliser **Postman** ou **curl** :

```bash
# Connexion
curl -X POST https://api.example.com/auth/login \
  -H "Content-Type: application/json" \
  -d '{"username":"user@example.com","password":"password123"}'

# Appel sécurisé
curl -X GET https://api.example.com/api/protected \
  -H "Authorization: Bearer eyJhbGciOiJIUzI1NiIs..."
```

## 📚 Ressources et Références

### Documentation Officielle
- [Microsoft - WPF Documentation](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/)
- [JWT.io - JSON Web Tokens](https://jwt.io/)
- [ASP.NET Core - Authentication](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/)

### Articles Recommandés
- [WPF MVVM Pattern](https://www.wpftutorial.net/)
- [JWT Best Practices](https://tools.ietf.org/html/rfc8725)
- [C# Security](https://docs.microsoft.com/en-us/dotnet/fundamentals/security/)

## 🤝 Contribution

Les contributions sont bienvenues ! Pour contribuer :

1. Fork le repository
2. Créer une branche pour votre fonctionnalité (`git checkout -b feature/AmazingFeature`)
3. Commit vos changements (`git commit -m 'Add some AmazingFeature'`)
4. Push vers la branche (`git push origin feature/AmazingFeature`)
5. Ouvrir une Pull Request

## 📝 License

Ce projet est sous la license **MIT**. Voir le fichier [LICENSE](LICENSE) pour plus de détails.

## 👤 Auteur

**ast116**  
- GitHub: [@ast116](https://github.com/ast116)

## 📮 Support

Si vous avez des questions ou rencontrez des problèmes :

1. Consultez les [Issues](https://github.com/ast116/Token_JWT/issues) existantes
2. Créez une [nouvelle Issue](https://github.com/ast116/Token_JWT/issues/new)
3. Attachez des logs et des informations sur votre environnement

---

<div align="center">

### ⭐ Si ce projet vous a été utile, n'hésitez pas à laisser une étoile !

**Dernière mise à jour** : 11 mai 2026

</div>
