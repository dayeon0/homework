# 여권 주세요! - Unity 타이틀 화면 설정 가이드

## 1. 이미지 파일 준비

`Assets/Resources/Images/` 폴더에 아래 파일을 복사하세요:
- `BG_Airport.png` → 인천공항 배경 이미지
- `Title_PassportLogo.png` → 여권 주세요! 타이틀 (배경 제거된 PNG)

## 2. 이미지 임포트 설정

각 이미지 선택 후 Inspector에서:
- Texture Type: **Sprite (2D and UI)**
- 배경 이미지: Max Size `2048`, Compression `Normal Quality`
- 타이틀 이미지: Alpha Is Transparency **체크**

---

## 3. Canvas 및 UI 계층 구조

```
Canvas  (Screen Space - Camera / Scale With Screen Size 1920×1080)
├── BG_Image            ← 배경 이미지 (Stretch 전체)
├── TitleGroup          ← CanvasGroup 컴포넌트 추가
│   └── Title_Image     ← 여권 주세요! 이미지
│       └── [TitleFloatAnimation.cs 부착]
└── ButtonGroup         ← CanvasGroup 컴포넌트 추가
    └── GameStartButton ← Button + Image 컴포넌트
        └── [GameStartButtonEffect.cs 부착]
```

---

## 4. 각 오브젝트 설정

### Canvas
- Render Mode: `Screen Space - Camera`
- UI Scale Mode: `Scale With Screen Size`
- Reference Resolution: `1920 × 1080`

### BG_Image (RawImage 또는 Image)
- Anchor: 전체 화면 스트레치 (Stretch All)
- Sprite: `BG_Airport`

### Title_Image
- Anchor: 화면 중앙 상단 (top-center)
- Pos Y: 약 `150 ~ 200` (화면 중앙보다 위)
- Width/Height: 원본 비율 유지, 약 `800 × 250`

**TitleFloatAnimation 컴포넌트 설정:**
| 항목 | 값 |
|------|-----|
| Float Amplitude | 15 |
| Float Speed | 1.2 |
| Use Pulse | ✓ |
| Pulse Amount | 0.03 |
| Pulse Speed | 1.5 |

### GameStartButton
- Anchor: 화면 중앙 하단
- Pos Y: 약 `-80`
- Width: `300`, Height: `80`
- Image Color: 흰색 (255,255,255)
- Normal Color: `#FFFFFF`
- Highlighted Color: `#FFE0F0` (연분홍)
- Pressed Color: `#DDDDDD`

**버튼 텍스트 (Text Mesh Pro):**
- 텍스트: `게임 시작`
- Font Size: `48`
- Font Style: Bold
- Color: `#1A1A2E` (어두운 남색)
- Alignment: Center

**GameStartButtonEffect 컴포넌트 설정:**
| 항목 | 값 |
|------|-----|
| Hover Scale | 1.08 |
| Press Scale | 0.95 |
| Lerp Speed | 12 |
| Use Blink | ✓ |
| Blink Speed | 1.8 |
| Blink Min | 0.75 |

---

## 5. MainMenuManager 설정

빈 GameObject `[MainMenuManager]` 생성 후 `MainMenuManager.cs` 부착:
- Title Canvas Group → `TitleGroup`
- Button Canvas Group → `ButtonGroup`
- Game Start Button → `GameStartButton`
- Game Scene Name → `"GameScene"` (다음 씬 이름)

---

## 6. 씬 저장 및 Build Settings

1. File → Save Scene → `MainMenu`
2. File → Build Settings → 씬 추가 순서:
   - Index 0: `MainMenu`
   - Index 1: `GameScene`

---

## 7. 최종 화면 구성 미리보기

```
┌─────────────────────────────────┐
│  [인천공항 픽셀아트 배경]          │
│                                  │
│      ╔══════════════╗            │
│      ║ 여권 주세요! ║  ← 둥실둥실 │
│      ╚══════════════╝            │
│                                  │
│         ┌──────────┐             │
│         │ 게임 시작 │ ← 깜빡임   │
│         └──────────┘             │
└─────────────────────────────────┘
```
