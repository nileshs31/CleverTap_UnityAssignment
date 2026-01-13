# CleverTap_UnityAssignment
Unity assignment done for CleverTap

---

## Overview

This submission contains **two Unity projects**:

- **Toast SDK (Unity Package)**
  - Displays Toast / Snackbar–like messages on **Android**, **iOS**, and **Editor**
  - Supports both **native platform toasts** and **custom Unity UI toasts**

- **Weather App (Unity Application)**
  - Fetches user location (latitude & longitude)
  - Calls the **Open-Meteo Weather API**
  - Displays weather information using the **Toast SDK**

---

## Projects Included

### Toast SDK (Unity Package)
- Folder: `Nilesh_ToastSDK`
- Delivered as a reusable **Unity Package**
- Can be imported into any Unity project

### Weather App (Unity Application)
- Uses the Toast SDK package
- Demonstrates real-world SDK usage
- Shows weather data using:
  - Native Toast
  - Custom Unity Toast

---

## Toast SDK (Unity Package)

### Features

#### Native Toast Support
- **Android** – Native Android Toast
- **iOS** – Native UIKit-based toast via `.mm` plugin

#### Custom Unity Toast
- Canvas-based UI toast
- Fade-in / fade-out animation using `CanvasGroup`

#### Editor Support
- Toast calls are logged to the Unity Console

#### Single Public API
- Platform handling is fully abstracted internally


## Full Documentation with Screenshots and Video Recordings
- https://docs.google.com/document/d/1oi3OaTYsUXWoLioW3PnAKWp0dhAsa4G_8J24szn7UDk/edit?usp=sharing
