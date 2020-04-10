CREATE TABLE "UserAccounts" (
	"Username" VARCHAR(255) PRIMARY KEY,
	"PasswordHash" CHAR(96) NOT NULL
)