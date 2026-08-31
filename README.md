# VaderConsulting.FontComboBox

C# .NET 3.5 WinForms library that subclasses ComboBox into an owner-drawn font picker. `FontComboBox` enumerates installed `FontFamily` names via `InstalledFontCollection` at runtime (skipped in the designer), then owner-draws each drop-down item in that typeface - Regular if available, otherwise Italic, Bold, or Microsoft Sans Serif. Autocomplete is SuggestAppend against the list items, the drop-down is 300 pixels high with up to 20 visible items, and the constructor is `internal` so the control is meant for use inside the VaderConsulting assembly family.

**Source last updated:** 2015-02-13 · **Language:** C# · **Target:** .NET Framework 3.5 · **Output:** class library (`Library`)

## Solution structure

| Project | Language | Type | Purpose |
|---------|----------|------|---------|
| `VaderConsulting.FontComboBox` (`VaderConsulting.FontComboBox.csproj`) | C# | class library (`net35`, WinForms `Component`) | Owner-drawn `ComboBox` that lists installed fonts and renders each item in its own typeface. |

## How to open

Open `VaderConsulting.FontComboBox.csproj` in Visual Studio 2013 or later (ToolsVersion 12.0). There is no `.sln` in this folder.

## Attribution and provenance

Working copy from Dave Robinson's OneDrive Historical Dev folder `VaderConsulting.FontComboBox`. Assembly title/product `VaderConsulting.FontComboBox`; copyright `Copyright ©  2015`; company empty. Namespace `VaderConsulting`.

## License

MIT © 2026 VaderConsulting. See `LICENSE`.
