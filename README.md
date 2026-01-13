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

## Weather App

### Features
- Fetches latitude & longitude using Unity Location Services
- Uses **Open-Meteo API** to fetch weather data
- Displays:
  - Latitude
  - Longitude
  - Temperature
- Shows results using:
  - Native Toast
  - Custom Unity Toast

---

### Responsibilities

**LocationService**
- Handles runtime permissions
- Provides fallback coordinates if location is unavailable

**WeatherService**
- Makes network request
- Parses temperature from API response

**WeatherUIController**
- Connects UI → services → Toast SDK

---

## Unit Testing

### Framework
- Unity Test Framework (NUnit)
- EditMode tests

### Coverage
- Weather JSON parsing
- Valid responses
- Missing or malformed data
- Edge cases:
  - Empty arrays
  - Missing fields

### Why EditMode Tests
- Fast execution
- No scene required
- No network dependency
- Platform-independent

---

## Build & Platform Notes

### Android
- Tested on a physical Android device
- Verified:
  - Native Android Toast
  - Custom Unity Toast

### iOS
- Tested on iOS Simulator via Xcode
- Uses `.mm` native plugin (UIKit-based toast)
- Location permission handled via `Info.plist`

### Editor
- Toast calls logged to the Unity Console

---

## Build Notes

Both the **Toast SDK** and the **Weather App** are production-ready and extensible.

This project demonstrates:
- Clean SDK architecture
- Cross-platform abstraction
- Native plugin integration
- Practical SDK usage in Unity
- Unit testing with proper assembly separation

## Full Documentation
https://docs.google.com/document/d/1oi3OaTYsUXWoLioW3PnAKWp0dhAsa4G_8J24szn7UDk/edit?usp=sharing

## Screen Recording Videos

### Editor
Toast Project - https://drive.google.com/file/d/13xBgHWcgssITETXZTg_GTF3lYbrCcGJn

Weather App - https://drive.google.com/file/d/1I6VSBT5H6zX8bGFEgBrTZq_K3I5qxY0m

### Android
Toast Project - https://drive.google.com/file/d/1_dy770_5gVnwh44qw6-eY2hWpbIRGXfq

Weather App - https://drive.google.com/file/d/13ROdochQIlxi7ALNePdgz-UwPzrQaHOR

### iOS
Toast Project - https://drive.google.com/file/d/1cAWn4XnRpBFpXeKPz4RhFQ9gXHKpE6K3

Weather App - https://drive.google.com/file/d/1vItzYVd0JYAIWkmr1dGdbu003wzjT0Av

