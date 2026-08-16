# `mait-stats` — guía de trabajo

> Backlog y sprints: [`docs/ROADMAP.md`](docs/ROADMAP.md).
> Reglas comunes a toda la plataforma: `../entrega/`.

## Qué es

Estadísticas. **Servicio retirado del workspace** (`H12 DROPPED`).

## Alcance

**Dentro:** nada en curso: el servicio no se utiliza.

**Fuera:** la lógica de otros servicios; los stacks y el despliegue, que son de
`mait-kubernetes`; y las decisiones transversales, que viven en `../entrega/`.

## Cómo se construye y se prueba

```bash
dotnet restore
dotnet build -c Release --no-restore
dotnet test  -c Release --no-build
```

⚠️ **Este repo no tiene tests**: `dotnet test` no ejecuta nada. Ver el roadmap.

## Reglas que hereda de la plataforma

- **No valida JWT.** Lo hace el gateway, que inyecta `X-MAIT-User` y
  `X-MAIT-Roles`. Añadir `AddJwtBearer` o `[Authorize]` aquí es deuda, no
  diseño — ADR-0001.
- **Multi-motor de BD por configuración**: `DataServiceOptions:TypeDb` y
  `ConnectionString`, nunca `DbOptions` — ADR-0003.
- **Errores con `ProblemDetails`**, sin `InnerException` ni trazas — ADR-0004.
- **Logs con `CorrelationId`** vía `MAIT.Observability`.

## 🔴 Este repositorio es PÚBLICO

El único de la organización. Cualquier credencial que contenga —y contiene la
contraseña compartida de PostgreSQL— está expuesta a internet, a diferencia de
los otros 24 repos que la comparten.

**Antes de tocar nada aquí, leer `STA-1` del roadmap.**

## Antes de abrir el PR

- [ ] Build y tests en verde.
- [ ] Item de `docs/ROADMAP.md` referenciado.
- [ ] Sin secretos nuevos en código ni en `appsettings*`.
- [ ] El resto del checklist común: `../entrega/convenciones/commits-y-pr.md`.
