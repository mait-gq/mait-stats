# Roadmap — `mait-stats`

> Actualizado: **2026-08-16** · Prefijo de IDs: `STA`
> Reglas de trabajo del repo: [`../AGENTS.md`](../AGENTS.md).
> Lo transversal: `../../ROADMAP.md` y `../../entrega/`.

## Qué es este servicio

Servicio de estadísticas. **Retirado del workspace**: el roadmap de plataforma lo
marcó como `H12 DROPPED` — «servicio eliminado del workspace (no se utiliza)».

Es además **el único repositorio público** de la organización.

| | |
|---|---|
| **Tecnología** | .NET 10 · `MAIT.Dto` **4.1.1** (la versión más antigua en uso) |
| **Rama** | `main` |
| **Visibilidad** | 🔴 **público** — el único de la organización |
| **Corre en** | ningún stack |
| **Tests** | ninguno (la carpeta `tests/` tiene un cuaderno Jupyter) |
| **Último commit** | 2026-05-06 |

## Deuda conocida

| ID | Qué | Por qué duele | Estado |
|---|---|---|---|
| `STA-D1` | 🔴 **El repositorio es público**, y contiene la contraseña compartida de PostgreSQL | Los otros 24 repos con esa credencial son privados. Este no. Es la vía de fuga más directa de `X1` | ABIERTA — **revisar con prioridad, aunque el servicio esté retirado** |
| `STA-D2` | `MAIT.Dto` en **4.1.1**, cuatro versiones por detrás | Irrelevante mientras no se use, pero lo mantiene fuera de cualquier campaña transversal | INFORMATIVA |
| `STA-D3` | Está marcado como retirado (`H12 DROPPED`) pero **el repositorio sigue vivo** y con `pr.yml` | Un repo retirado que parece activo confunde el inventario | ABIERTA |

## Sprint en curso — `STA-S1`: decidir si se archiva

**Objetivo:** No tiene sentido invertir aquí. Lo único que importa es la exposición pública y
cerrar el estado del repo.

| ID | Tarea | Estado |
|---|---|---|
| `STA-1` | 🔴 Comprobar qué credenciales contiene y **rotar las que estén expuestas por ser público** | TODO — prioritario pese al estado del servicio |
| `STA-2` | Decidir: archivar el repositorio, hacerlo privado, o reincorporarlo | TODO — decisión |

**Hecho cuando:** el repositorio está archivado o privado, y ninguna credencial viva sigue en su
historial público.

## Backlog

> Sin backlog funcional: el servicio está retirado. Si se reincorpora, este
> roadmap se reescribe entero.

---

## Hecho

### `H12` — retirado del workspace · sprint 2
«Servicio eliminado del workspace (no se utiliza)». Salió de
`mait.code-workspace` y de la lista de servicios activos.
