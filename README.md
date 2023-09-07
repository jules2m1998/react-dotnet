# MANAGEMENT

Un projet en ASP.NET et REACT pour tester mes competences dans ces deux outils

## Objectifs

Creer une application de gestion des commandes et ceux en utilisant des concepts comme:

- Les apis avec Asp.net core web api
- Du front end avec React
- Des tests unitaires BDD avec speckflow

  - React (jest - TDD, cypress - BDD)
  - Dotnet (XUnit)

## Setup

### I. BACKEND✅

1. Definition de l'architecture de project pour le backend ✅
2. Definition de la structure des tests backend et ecriture des premiers tests ✅
3. Implementation du CQRS avec le design pattern Mediator ✅
4. Ajout du mapper pour la conversion des donnees en DTOs avec AutoMapper ✅
5. Ecriture d'une feature de test ✅
6. Gestion des erreures ✅

    - Definir la structure d'une erreure✅
    - Utilisation d'un builder pour la contruction d'une erreure✅
    - Implementation de la gestion des erreures✅
7. Gestion des reponses et de la pagination✅
8. Gestion des fichiers statiques✅

### FRONTEND🕜

1. Defintion de l'architecture de projet pour le front✅
2. Implementation des tests unitaires et e2e🕜
3. Gestion des requetes http et de erreures http
4. Ajout du store
5. Authorization avec routing

## Features

### 1. **Authentification :**

- Authentification par mot de passe avec réinitialisation du mot de passe.
- Authentification à deux facteurs (2FA) pour une sécurité renforcée.

### 2. **Gestion des Utilisateurs :**

- Création de comptes utilisateur avec des rôles définis (administrateur, employé, client).
- Possibilité de lier le compte à des réseaux sociaux (connexion via Facebook, Google, etc.).
- Confirmation de l'adresse e-mail avec un lien de confirmation envoyé lors de l'inscription.

### 3. **Gestion des Commandes :**

- Création, modification et suppression de commandes.
- Attribution des commandes aux employés.
- Suivi en temps réel de l'état des commandes.
- Historique des commandes avec détails complets.

### 4. **Catalogue de Produits :**

- Ajout, modification et suppression de produits.
- Catégorisation des produits pour une navigation facile.
- Images, descriptions et prix des produits.

### 5. **Panier d'Achat :**

- Ajout et suppression de produits au panier.
- Calcul automatique du montant total.
- Possibilité de sauvegarder le panier pour un achat ultérieur.

### 6. **Paiement en Ligne :**

- Intégration de passerelles de paiement sécurisées (PayPal, Stripe, etc.).
- Gestion des remises et des codes promotionnels.

### 7. **Notifications :**

- Notifications en temps réel pour les mises à jour de commandes.
- Notifications par e-mail pour les confirmations de commande et les rappels.

### 8. **Gestion des Profils :**

- Profils utilisateur personnalisés avec des informations telles que l'adresse de livraison, les coordonnées, etc.

### 9. **Système de Commentaires et d'Avis :**

- Possibilité pour les clients de laisser des commentaires et des avis sur les produits.

### 10. **Sécurité :**

- Cryptage des données sensibles.
- Protection contre les attaques CSRF, XSS, et autres vulnérabilités de sécurité.

### 11. **Analytiques :**

- Suivi des données sur l'utilisation de l'application.
- Génération de rapports pour l'analyse des ventes et des performances.

### 12. **Langues et Localisation :**

- Support de plusieurs langues.
- Adaptation aux paramètres de localisation (monnaie, fuseau horaire, formats de date).

### 13. **Assistance et Support :**

- Possibilité pour les utilisateurs de contacter le support en cas de problème.

### 14. **Évolutivité :**

- Conception extensible pour permettre l'ajout de nouvelles fonctionnalités à l'avenir.

### 15. **Documentation :**

- Fournir une documentation détaillée pour les utilisateurs et les développeurs.

### 16. **Tests et Déploiement :**

- Effectuer des tests rigoureux pour garantir la stabilité et la sécurité de l'application.
- Déploiement sur des serveurs sécurisés et évolutifs.
