# CSM Security Database CHANGELOG

## [X.X.X] - xx.xx.xxxx

### Patch

- Added Vendor table and tests.
- old accounts junction tables dropped and replaced by new ones with proper naming.

## [2.0.0] - 15.02-2026

### Patch

- Added XML package doc for package consumers.

#### Dependencies

| Package                                 | Previous Version | New Version     |
|:----------------------------------------|:----------------:|:---------------:|
| CSM.Database.Core                       | 4.1.2            | 4.2.3           |
| Microsoft.EntityFrameworkCore.Design	  | 10.0.1           | 10.0.3          |

## [1.0.1] - 25.12-2025

### Patch

- Added extension to subscribe automatically all security database services required.

#### Dependencies

| Package                                 | Previous Version | New Version     |
|:----------------------------------------|:----------------:|:---------------:|
| CSM.Database.Core                       | 4.1.2            | 4.1.2           |
| Microsoft.EntityFrameworkCore.Design	  | 10.0.1           | 10.0.1          |

## [1.0.0] - 24.12-2025

### Init

- Initialized package adding resources for a DB Creation using EF Core about security.

#### Dependencies

| Package                                 | Previous Version | New Version     |
|:----------------------------------------|:----------------:|:---------------:|
| CSM.Database.Core                       | -.-.-            | 4.1.2           |
| Microsoft.EntityFrameworkCore.Design	  | -.-.-            | 10.0.1          |