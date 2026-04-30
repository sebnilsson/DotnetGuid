# Repository Guidelines

Use the `caveman` skill for all communication, except for when writing public documentation.

## Keep This File Durable
Only keep guidance here that is repo-specific, easy to miss, or expensive to rediscover from the codebase. Avoid repeating file inventories, command lists, version numbers, or architecture summaries that can drift over time.

## Coding Conventions
Follow `.editorconfig` and treat it as the formatting source of truth. Preserve existing Windows line endings (`CRLF`) in edited text files to avoid Visual Studio line-ending churn.

Prefer `var`, keep `System` using directives first, and keep file/class names aligned. Nullable reference types are enabled, so handle nulls explicitly.

## Tests
Keep tests deterministic and match the existing xUnit style. Use explicit `// Arrange`, `// Act`, and `// Assert` comments in each test method.

## Change Checklist
After code changes:
- Ensure edited text files still use `CRLF`
- Run `dotnet format`
- Run `dotnet test -c Release -v minimal --no-restore`

After any meaningful behavior change:
- Update relevant documentation
- Add lasting, non-obvious repo guidance here if you learned something future agents would otherwise have to rediscover
