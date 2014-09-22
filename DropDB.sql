IF OBJECT_ID('__MigrationHistory', 'U') IS NOT NULL
  DROP TABLE __MigrationHistory;
IF OBJECT_ID('Slots', 'U') IS NOT NULL
  DROP TABLE Slots;
IF OBJECT_ID('UserProfileProjectModels', 'U') IS NOT NULL
  DROP TABLE UserProfileProjectModels;
IF OBJECT_ID('ProjectModelUserProfiles', 'U') IS NOT NULL
  DROP TABLE ProjectModelUserProfiles;
IF OBJECT_ID('ProjectsUsers', 'U') IS NOT NULL
  DROP TABLE ProjectsUsers;
  IF OBJECT_ID('UsersProjects', 'U') IS NOT NULL
  DROP TABLE UsersProjects;
IF OBJECT_ID('Tasks', 'U') IS NOT NULL
  DROP TABLE Tasks;
IF OBJECT_ID('Projects', 'U') IS NOT NULL
  DROP TABLE Projects;
IF OBJECT_ID('Users', 'U') IS NOT NULL
  DROP TABLE Users;
IF OBJECT_ID('Statuses', 'U') IS NOT NULL
  DROP TABLE Statuses;
IF OBJECT_ID('Priorities', 'U') IS NOT NULL
  DROP TABLE Priorities;
IF OBJECT_ID('Types', 'U') IS NOT NULL
  DROP TABLE Types;
IF OBJECT_ID('Categories', 'U') IS NOT NULL
  DROP TABLE Categories;
IF OBJECT_ID('webpages_UsersInRoles', 'U') IS NOT NULL
  DROP TABLE webpages_UsersInRoles;
IF OBJECT_ID('webpages_RolesUserProfile', 'U') IS NOT NULL
  DROP TABLE webpages_RolesUserProfile;
IF OBJECT_ID('UserProfiles', 'U') IS NOT NULL
  DROP TABLE UserProfiles;
IF OBJECT_ID('webpages_Membership', 'U') IS NOT NULL
  DROP TABLE webpages_Membership;
IF OBJECT_ID('webpages_OAuthMembership', 'U') IS NOT NULL
  DROP TABLE webpages_OAuthMembership;
IF OBJECT_ID('webpages_Roles', 'U') IS NOT NULL
  DROP TABLE webpages_Roles;