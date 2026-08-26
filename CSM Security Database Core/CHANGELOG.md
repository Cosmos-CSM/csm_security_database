# CSM Security Database CHANGELOG

## [x.x.x] - xx.xx.xxxx

### Patch

- Added [Entity State] entity to track the state of entities in the database.

#### Dependencies

| Package                                 | Previous Version | New Version     |
|:----------------------------------------|:----------------:|:---------------:|
| CSM.Database.Core                       | 6.1.0            | 7.0.0           |

## [3.1.0] - 24.06.2026

### Patch

- Updated [CSM.Database.Core] to impact version.

#### Dependencies

| Package                                 | Previous Version | New Version     |
|:----------------------------------------|:----------------:|:---------------:|
| CSM.Database.Core                       | 6.0.6            | 6.1.0           |
| Microsoft.EntityFrameworkCore.Design	  | 10.0.9           | 10.0.9          |

## [3.0.0] - 19.06.2026

### Patch

- Added Vendor feature and tests.

- Old accounts junction tables dropped and replaced by new ones with proper naming.

### Fixes

- [Updates] operations fixed for complex relations. 

#### Dependencies

| Package                                 | Previous Version | New Version     |
|:----------------------------------------|:----------------:|:---------------:|
| CSM.Database.Core                       | 4.2.3            | 6.0.6           |
| Microsoft.EntityFrameworkCore.Design	  | 10.0.3           | 10.0.9          |

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