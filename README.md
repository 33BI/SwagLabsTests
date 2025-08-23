# SwagLabsTests

Automated tests for Swag Labs using SpecFlow, C# and Playwright.

## Setup

```bash
git clone https://github.com/yourusername/SwagLabsTests.git
cd SwagLabsTests
dotnet restore
playwright install chromium
dotnet test
```

## What's Tested

- Shopping cart functionality
- T-shirt purchasing (view details, add to cart, checkout)
- Product purchasing flow
- User login and checkout process

## Running Tests

```bash
# Run all tests
dotnet test
```

## CI/CD Pipeline

Tests run automatically on push/PR. Manual runs require Swag Labs credentials.

**To run manually:**
1. Go to Actions → "SpecFlow Tests CI/CD"
2. Click "Run workflow"
3. Enter username: `standard_user`
4. Enter password: `secret_sauce`

## Project Structure

```
Features/           # Test scenarios
PageObjects/        # Page automation code
Steps/              # Test step definitions
.github/workflows/  # CI/CD pipeline
```

## Configuration

Set environment variables:
- `SWAG_LABS_USERNAME` (default: standard_user)
- `SWAG_LABS_PASSWORD` (default: secret_sauce)