CREATE DATABASE [{{DATABASE_NAME}}]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'{{DATABASE_NAME}}', FILENAME = N'/var/opt/mssql/data/{{DATABASE_NAME}}.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'{{DATABASE_NAME}}_log', FILENAME = N'/var/opt/mssql/data/{{DATABASE_NAME}}_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 COLLATE SQL_Latin1_General_CP1_CI_AS
GO
ALTER DATABASE [{{DATABASE_NAME}}] SET COMPATIBILITY_LEVEL = 120
GO
ALTER DATABASE [{{DATABASE_NAME}}] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [{{DATABASE_NAME}}] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [{{DATABASE_NAME}}] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [{{DATABASE_NAME}}] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [{{DATABASE_NAME}}] SET ARITHABORT OFF 
GO
ALTER DATABASE [{{DATABASE_NAME}}] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [{{DATABASE_NAME}}] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [{{DATABASE_NAME}}] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [{{DATABASE_NAME}}] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [{{DATABASE_NAME}}] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [{{DATABASE_NAME}}] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [{{DATABASE_NAME}}] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [{{DATABASE_NAME}}] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [{{DATABASE_NAME}}] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [{{DATABASE_NAME}}] SET  DISABLE_BROKER 
GO
ALTER DATABASE [{{DATABASE_NAME}}] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [{{DATABASE_NAME}}] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [{{DATABASE_NAME}}] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [{{DATABASE_NAME}}] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [{{DATABASE_NAME}}] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [{{DATABASE_NAME}}] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [{{DATABASE_NAME}}] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [{{DATABASE_NAME}}] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [{{DATABASE_NAME}}] SET  MULTI_USER 
GO
ALTER DATABASE [{{DATABASE_NAME}}] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [{{DATABASE_NAME}}] SET DB_CHAINING OFF 
GO
ALTER DATABASE [{{DATABASE_NAME}}] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [{{DATABASE_NAME}}] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [{{DATABASE_NAME}}] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [{{DATABASE_NAME}}] SET QUERY_STORE = OFF
GO