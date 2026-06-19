# CSM Security Database Testing CHANGELOG

## [3.0.0] - 19.06-2026

### Changes

- [Store] methods are now asynchronouse since some results need to be waited during processing.

#### Dependencies

| Package                                 | Previous Version | New Version     |
|:----------------------------------------|:----------------:|:---------------:|
| CSM.Foundation.Core                     | 3.0.1            | 4.0.0           |
| CSM.Database.Testing					  | 5.0.0            | 7.0.2           |
| xunit.v3								  | -.-.-            | 3.2.2           |

## [2.0.1] - 10.03-2026

### Patch

- Fixed at [DraftUtils] an error where drafting an [User] it wasn´t drafting its [UserInfo] when there´s no one.

#### Dependencies

| Package                                 | Previous Version | New Version     |
|:----------------------------------------|:----------------:|:---------------:|
| CSM.Foundation.Core                     | 3.0.1            | 3.0.1           |
| CSM.Database.Testing					  | 5.0.0            | 5.0.0           |

## [2.0.0] - 15.02-2026

### Patch

- Initialized package adding resources for a DB Creation using EF Core about security.

#### Dependencies

| Package                                 | Previous Version | New Version     |
|:----------------------------------------|:----------------:|:---------------:|
| CSM.Foundation.Core                     | 2.1.0            | 3.0.1           |
| CSM.Database.Testing					  | -.-.-            | 5.0.0           |
| CSM.Foundation.Testing            	  | 4.1.2            | x.x.x           |

## [1.0.0] - 24.12-2025

### Init

- Initialized package adding resources for a DB Creation using EF Core about security.

#### Dependencies

| Package                                 | Previous Version | New Version     |
|:----------------------------------------|:----------------:|:---------------:|
| CSM.Foundation.Core                     | -.-.-            | 2.1.0           |
| CSM.Foundation.Testing            	  | -.-.-            | 4.1.2           |