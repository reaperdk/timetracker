IF OBJECT_ID('__MigrationHistory', 'U') IS NOT NULL
  DROP TABLE __MigrationHistory;
IF OBJECT_ID('SlotModels', 'U') IS NOT NULL
  DROP TABLE SlotModels;
IF OBJECT_ID('UserProfileProjectModels', 'U') IS NOT NULL
  DROP TABLE UserProfileProjectModels;
IF OBJECT_ID('ProjectModelUserProfiles', 'U') IS NOT NULL
  DROP TABLE ProjectModelUserProfiles;
IF OBJECT_ID('TaskModels', 'U') IS NOT NULL
  DROP TABLE TaskModels;
IF OBJECT_ID('ProjectModels', 'U') IS NOT NULL
  DROP TABLE ProjectModels;
IF OBJECT_ID('UserModels', 'U') IS NOT NULL
  DROP TABLE UserModels;
IF OBJECT_ID('StatusModels', 'U') IS NOT NULL
  DROP TABLE StatusModels;
IF OBJECT_ID('PriorityModels', 'U') IS NOT NULL
  DROP TABLE PriorityModels;
IF OBJECT_ID('TypeModels', 'U') IS NOT NULL
  DROP TABLE TypeModels;
IF OBJECT_ID('CategoryModels', 'U') IS NOT NULL
  DROP TABLE CategoryModels;
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