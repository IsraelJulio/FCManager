using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullControlFootball.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "character varying(320)", maxLength: 320, nullable: false),
                    PasswordHash = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ProfileImageUrl = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    PreferredTheme = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    LastLoginAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "competitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(180)", maxLength: 180, nullable: false),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: true),
                    CompetitionType = table.Column<int>(type: "integer", nullable: false),
                    Tier = table.Column<int>(type: "integer", nullable: true),
                    IsDomestic = table.Column<bool>(type: "boolean", nullable: false),
                    IsContinental = table.Column<bool>(type: "boolean", nullable: false),
                    ExternalSource = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ExternalId = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_competitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_competitions_countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(180)", maxLength: 180, nullable: false),
                    KnownAs = table.Column<string>(type: "character varying(180)", maxLength: 180, nullable: true),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: true),
                    NationalityCountryId = table.Column<Guid>(type: "uuid", nullable: true),
                    PrimaryPosition = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    SecondaryPositions = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    OverallBase = table.Column<int>(type: "integer", nullable: true),
                    PotentialBase = table.Column<int>(type: "integer", nullable: true),
                    PreferredFoot = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    FaceImageUrl = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    ExternalSource = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ExternalId = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_players_countries_NationalityCountryId",
                        column: x => x.NationalityCountryId,
                        principalTable: "countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "refresh_tokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Token = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ExpiresAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RevokedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CreatedByIp = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    RevokedByIp = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refresh_tokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_refresh_tokens_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_auth_providers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Provider = table.Column<int>(type: "integer", nullable: false),
                    ProviderUserId = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ProviderEmail = table.Column<string>(type: "character varying(320)", maxLength: 320, nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_auth_providers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_auth_providers_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "clubs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(180)", maxLength: 180, nullable: false),
                    ShortName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: true),
                    DefaultCompetitionId = table.Column<Guid>(type: "uuid", nullable: true),
                    LogoUrl = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    PrimaryColor = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    SecondaryColor = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    ExternalSource = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ExternalId = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clubs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_clubs_competitions_DefaultCompetitionId",
                        column: x => x.DefaultCompetitionId,
                        principalTable: "competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_clubs_countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "career_saves",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    MainClubId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    GameEdition = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CurrentSeasonNumber = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_career_saves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_career_saves_clubs_MainClubId",
                        column: x => x.MainClubId,
                        principalTable: "clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_career_saves_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "club_players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClubId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uuid", nullable: false),
                    ShirtNumber = table.Column<int>(type: "integer", nullable: true),
                    SquadRole = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ImportedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_club_players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_club_players_clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_club_players_players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "save_clubs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CareerSaveId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClubId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClubNameSnapshot = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    IsUserClub = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_save_clubs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_save_clubs_career_saves_CareerSaveId",
                        column: x => x.CareerSaveId,
                        principalTable: "career_saves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_save_clubs_clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "seasons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CareerSaveId = table.Column<Guid>(type: "uuid", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    Label = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    StartedAt = table.Column<DateOnly>(type: "date", nullable: true),
                    EndedAt = table.Column<DateOnly>(type: "date", nullable: true),
                    IsFinished = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_seasons_career_saves_CareerSaveId",
                        column: x => x.CareerSaveId,
                        principalTable: "career_saves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "save_players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CareerSaveId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CurrentClubId = table.Column<Guid>(type: "uuid", nullable: true),
                    PlayerNameSnapshot = table.Column<string>(type: "character varying(180)", maxLength: 180, nullable: false),
                    OverallCurrent = table.Column<int>(type: "integer", nullable: true),
                    PotentialCurrent = table.Column<int>(type: "integer", nullable: true),
                    AgeSnapshot = table.Column<int>(type: "integer", nullable: true),
                    PrimaryPositionSnapshot = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    IsRetired = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_save_players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_save_players_career_saves_CareerSaveId",
                        column: x => x.CareerSaveId,
                        principalTable: "career_saves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_save_players_players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_save_players_save_clubs_CurrentClubId",
                        column: x => x.CurrentClubId,
                        principalTable: "save_clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "season_competitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CareerSaveId = table.Column<Guid>(type: "uuid", nullable: false),
                    SeasonId = table.Column<Guid>(type: "uuid", nullable: false),
                    CompetitionId = table.Column<Guid>(type: "uuid", nullable: false),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: true),
                    NameSnapshot = table.Column<string>(type: "character varying(180)", maxLength: 180, nullable: false),
                    CompetitionType = table.Column<int>(type: "integer", nullable: false),
                    IsUserParticipating = table.Column<bool>(type: "boolean", nullable: false),
                    StartedAt = table.Column<DateOnly>(type: "date", nullable: true),
                    EndedAt = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_season_competitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_season_competitions_career_saves_CareerSaveId",
                        column: x => x.CareerSaveId,
                        principalTable: "career_saves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_season_competitions_competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_season_competitions_countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_season_competitions_seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transfer_windows",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CareerSaveId = table.Column<Guid>(type: "uuid", nullable: false),
                    SeasonId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IsOpen = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transfer_windows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_transfer_windows_career_saves_CareerSaveId",
                        column: x => x.CareerSaveId,
                        principalTable: "career_saves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transfer_windows_seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "competition_standings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SeasonCompetitionId = table.Column<Guid>(type: "uuid", nullable: false),
                    SnapshotDateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsFinal = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_competition_standings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_competition_standings_season_competitions_SeasonCompetition~",
                        column: x => x.SeasonCompetitionId,
                        principalTable: "season_competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "competition_top_assists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SeasonCompetitionId = table.Column<Guid>(type: "uuid", nullable: false),
                    SavePlayerId = table.Column<Guid>(type: "uuid", nullable: true),
                    PlayerId = table.Column<Guid>(type: "uuid", nullable: true),
                    SaveClubId = table.Column<Guid>(type: "uuid", nullable: true),
                    ClubId = table.Column<Guid>(type: "uuid", nullable: true),
                    PlayerNameSnapshot = table.Column<string>(type: "character varying(180)", maxLength: 180, nullable: false),
                    ClubNameSnapshot = table.Column<string>(type: "character varying(180)", maxLength: 180, nullable: true),
                    Position = table.Column<int>(type: "integer", nullable: false),
                    Assists = table.Column<int>(type: "integer", nullable: false),
                    SnapshotDateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsFinal = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_competition_top_assists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_competition_top_assists_clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_competition_top_assists_players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_competition_top_assists_save_clubs_SaveClubId",
                        column: x => x.SaveClubId,
                        principalTable: "save_clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_competition_top_assists_save_players_SavePlayerId",
                        column: x => x.SavePlayerId,
                        principalTable: "save_players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_competition_top_assists_season_competitions_SeasonCompetiti~",
                        column: x => x.SeasonCompetitionId,
                        principalTable: "season_competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "competition_top_scorers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SeasonCompetitionId = table.Column<Guid>(type: "uuid", nullable: false),
                    SavePlayerId = table.Column<Guid>(type: "uuid", nullable: true),
                    PlayerId = table.Column<Guid>(type: "uuid", nullable: true),
                    SaveClubId = table.Column<Guid>(type: "uuid", nullable: true),
                    ClubId = table.Column<Guid>(type: "uuid", nullable: true),
                    PlayerNameSnapshot = table.Column<string>(type: "character varying(180)", maxLength: 180, nullable: false),
                    ClubNameSnapshot = table.Column<string>(type: "character varying(180)", maxLength: 180, nullable: true),
                    Position = table.Column<int>(type: "integer", nullable: false),
                    Goals = table.Column<int>(type: "integer", nullable: false),
                    SnapshotDateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsFinal = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_competition_top_scorers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_competition_top_scorers_clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_competition_top_scorers_players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_competition_top_scorers_save_clubs_SaveClubId",
                        column: x => x.SaveClubId,
                        principalTable: "save_clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_competition_top_scorers_save_players_SavePlayerId",
                        column: x => x.SavePlayerId,
                        principalTable: "save_players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_competition_top_scorers_season_competitions_SeasonCompetiti~",
                        column: x => x.SeasonCompetitionId,
                        principalTable: "season_competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transfer_transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CareerSaveId = table.Column<Guid>(type: "uuid", nullable: false),
                    SeasonId = table.Column<Guid>(type: "uuid", nullable: false),
                    TransferWindowId = table.Column<Guid>(type: "uuid", nullable: true),
                    SavePlayerId = table.Column<Guid>(type: "uuid", nullable: true),
                    PlayerId = table.Column<Guid>(type: "uuid", nullable: true),
                    FromSaveClubId = table.Column<Guid>(type: "uuid", nullable: true),
                    ToSaveClubId = table.Column<Guid>(type: "uuid", nullable: true),
                    FromClubNameSnapshot = table.Column<string>(type: "character varying(180)", maxLength: 180, nullable: true),
                    ToClubNameSnapshot = table.Column<string>(type: "character varying(180)", maxLength: 180, nullable: true),
                    PlayerNameSnapshot = table.Column<string>(type: "character varying(180)", maxLength: 180, nullable: false),
                    TransferType = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    Currency = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    TransactionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transfer_transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_transfer_transactions_career_saves_CareerSaveId",
                        column: x => x.CareerSaveId,
                        principalTable: "career_saves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transfer_transactions_players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_transfer_transactions_save_clubs_FromSaveClubId",
                        column: x => x.FromSaveClubId,
                        principalTable: "save_clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_transfer_transactions_save_clubs_ToSaveClubId",
                        column: x => x.ToSaveClubId,
                        principalTable: "save_clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_transfer_transactions_save_players_SavePlayerId",
                        column: x => x.SavePlayerId,
                        principalTable: "save_players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_transfer_transactions_seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transfer_transactions_transfer_windows_TransferWindowId",
                        column: x => x.TransferWindowId,
                        principalTable: "transfer_windows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "competition_standing_rows",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompetitionStandingId = table.Column<Guid>(type: "uuid", nullable: false),
                    SaveClubId = table.Column<Guid>(type: "uuid", nullable: true),
                    ClubId = table.Column<Guid>(type: "uuid", nullable: true),
                    ClubNameSnapshot = table.Column<string>(type: "character varying(180)", maxLength: 180, nullable: false),
                    Position = table.Column<int>(type: "integer", nullable: false),
                    Played = table.Column<int>(type: "integer", nullable: false),
                    Wins = table.Column<int>(type: "integer", nullable: false),
                    Draws = table.Column<int>(type: "integer", nullable: false),
                    Losses = table.Column<int>(type: "integer", nullable: false),
                    GoalsFor = table.Column<int>(type: "integer", nullable: false),
                    GoalsAgainst = table.Column<int>(type: "integer", nullable: false),
                    GoalDifference = table.Column<int>(type: "integer", nullable: false),
                    Points = table.Column<int>(type: "integer", nullable: false),
                    FinalStatus = table.Column<int>(type: "integer", nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_competition_standing_rows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_competition_standing_rows_clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_competition_standing_rows_competition_standings_Competition~",
                        column: x => x.CompetitionStandingId,
                        principalTable: "competition_standings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_competition_standing_rows_save_clubs_SaveClubId",
                        column: x => x.SaveClubId,
                        principalTable: "save_clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_career_saves_MainClubId",
                table: "career_saves",
                column: "MainClubId");

            migrationBuilder.CreateIndex(
                name: "IX_career_saves_UserId",
                table: "career_saves",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_career_saves_UserId_Name",
                table: "career_saves",
                columns: new[] { "UserId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_club_players_ClubId",
                table: "club_players",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_club_players_ClubId_PlayerId_IsActive",
                table: "club_players",
                columns: new[] { "ClubId", "PlayerId", "IsActive" });

            migrationBuilder.CreateIndex(
                name: "IX_club_players_PlayerId",
                table: "club_players",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_clubs_CountryId",
                table: "clubs",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_clubs_DefaultCompetitionId",
                table: "clubs",
                column: "DefaultCompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_clubs_ExternalSource_ExternalId",
                table: "clubs",
                columns: new[] { "ExternalSource", "ExternalId" });

            migrationBuilder.CreateIndex(
                name: "IX_competition_standing_rows_ClubId",
                table: "competition_standing_rows",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_competition_standing_rows_CompetitionStandingId",
                table: "competition_standing_rows",
                column: "CompetitionStandingId");

            migrationBuilder.CreateIndex(
                name: "IX_competition_standing_rows_CompetitionStandingId_Position",
                table: "competition_standing_rows",
                columns: new[] { "CompetitionStandingId", "Position" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_competition_standing_rows_SaveClubId",
                table: "competition_standing_rows",
                column: "SaveClubId");

            migrationBuilder.CreateIndex(
                name: "IX_competition_standings_SeasonCompetitionId",
                table: "competition_standings",
                column: "SeasonCompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_competition_standings_SeasonCompetitionId_SnapshotDateUtc",
                table: "competition_standings",
                columns: new[] { "SeasonCompetitionId", "SnapshotDateUtc" });

            migrationBuilder.CreateIndex(
                name: "IX_competition_top_assists_ClubId",
                table: "competition_top_assists",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_competition_top_assists_PlayerId",
                table: "competition_top_assists",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_competition_top_assists_SaveClubId",
                table: "competition_top_assists",
                column: "SaveClubId");

            migrationBuilder.CreateIndex(
                name: "IX_competition_top_assists_SavePlayerId",
                table: "competition_top_assists",
                column: "SavePlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_competition_top_assists_SeasonCompetitionId",
                table: "competition_top_assists",
                column: "SeasonCompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_competition_top_assists_SeasonCompetitionId_SnapshotDateUtc~",
                table: "competition_top_assists",
                columns: new[] { "SeasonCompetitionId", "SnapshotDateUtc", "Position" });

            migrationBuilder.CreateIndex(
                name: "IX_competition_top_scorers_ClubId",
                table: "competition_top_scorers",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_competition_top_scorers_PlayerId",
                table: "competition_top_scorers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_competition_top_scorers_SaveClubId",
                table: "competition_top_scorers",
                column: "SaveClubId");

            migrationBuilder.CreateIndex(
                name: "IX_competition_top_scorers_SavePlayerId",
                table: "competition_top_scorers",
                column: "SavePlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_competition_top_scorers_SeasonCompetitionId",
                table: "competition_top_scorers",
                column: "SeasonCompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_competition_top_scorers_SeasonCompetitionId_SnapshotDateUtc~",
                table: "competition_top_scorers",
                columns: new[] { "SeasonCompetitionId", "SnapshotDateUtc", "Position" });

            migrationBuilder.CreateIndex(
                name: "IX_competitions_CountryId",
                table: "competitions",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_competitions_ExternalSource_ExternalId",
                table: "competitions",
                columns: new[] { "ExternalSource", "ExternalId" });

            migrationBuilder.CreateIndex(
                name: "IX_countries_Code",
                table: "countries",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_countries_Name",
                table: "countries",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_players_ExternalSource_ExternalId",
                table: "players",
                columns: new[] { "ExternalSource", "ExternalId" });

            migrationBuilder.CreateIndex(
                name: "IX_players_NationalityCountryId",
                table: "players",
                column: "NationalityCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_refresh_tokens_Token",
                table: "refresh_tokens",
                column: "Token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_refresh_tokens_UserId",
                table: "refresh_tokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_save_clubs_CareerSaveId",
                table: "save_clubs",
                column: "CareerSaveId");

            migrationBuilder.CreateIndex(
                name: "IX_save_clubs_CareerSaveId_ClubId",
                table: "save_clubs",
                columns: new[] { "CareerSaveId", "ClubId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_save_clubs_ClubId",
                table: "save_clubs",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_save_players_CareerSaveId",
                table: "save_players",
                column: "CareerSaveId");

            migrationBuilder.CreateIndex(
                name: "IX_save_players_CareerSaveId_PlayerId",
                table: "save_players",
                columns: new[] { "CareerSaveId", "PlayerId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_save_players_CurrentClubId",
                table: "save_players",
                column: "CurrentClubId");

            migrationBuilder.CreateIndex(
                name: "IX_save_players_PlayerId",
                table: "save_players",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_season_competitions_CareerSaveId",
                table: "season_competitions",
                column: "CareerSaveId");

            migrationBuilder.CreateIndex(
                name: "IX_season_competitions_CompetitionId",
                table: "season_competitions",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_season_competitions_CountryId",
                table: "season_competitions",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_season_competitions_SeasonId",
                table: "season_competitions",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_season_competitions_SeasonId_CompetitionId",
                table: "season_competitions",
                columns: new[] { "SeasonId", "CompetitionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_seasons_CareerSaveId",
                table: "seasons",
                column: "CareerSaveId");

            migrationBuilder.CreateIndex(
                name: "IX_seasons_CareerSaveId_Number",
                table: "seasons",
                columns: new[] { "CareerSaveId", "Number" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_transfer_transactions_CareerSaveId",
                table: "transfer_transactions",
                column: "CareerSaveId");

            migrationBuilder.CreateIndex(
                name: "IX_transfer_transactions_FromSaveClubId",
                table: "transfer_transactions",
                column: "FromSaveClubId");

            migrationBuilder.CreateIndex(
                name: "IX_transfer_transactions_PlayerId",
                table: "transfer_transactions",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_transfer_transactions_SavePlayerId",
                table: "transfer_transactions",
                column: "SavePlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_transfer_transactions_SeasonId",
                table: "transfer_transactions",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_transfer_transactions_ToSaveClubId",
                table: "transfer_transactions",
                column: "ToSaveClubId");

            migrationBuilder.CreateIndex(
                name: "IX_transfer_transactions_TransactionDate",
                table: "transfer_transactions",
                column: "TransactionDate");

            migrationBuilder.CreateIndex(
                name: "IX_transfer_transactions_TransferWindowId",
                table: "transfer_transactions",
                column: "TransferWindowId");

            migrationBuilder.CreateIndex(
                name: "IX_transfer_windows_CareerSaveId",
                table: "transfer_windows",
                column: "CareerSaveId");

            migrationBuilder.CreateIndex(
                name: "IX_transfer_windows_SeasonId",
                table: "transfer_windows",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_transfer_windows_SeasonId_Name",
                table: "transfer_windows",
                columns: new[] { "SeasonId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_auth_providers_Provider_ProviderUserId",
                table: "user_auth_providers",
                columns: new[] { "Provider", "ProviderUserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_auth_providers_UserId",
                table: "user_auth_providers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_users_Email",
                table: "users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "club_players");

            migrationBuilder.DropTable(
                name: "competition_standing_rows");

            migrationBuilder.DropTable(
                name: "competition_top_assists");

            migrationBuilder.DropTable(
                name: "competition_top_scorers");

            migrationBuilder.DropTable(
                name: "refresh_tokens");

            migrationBuilder.DropTable(
                name: "transfer_transactions");

            migrationBuilder.DropTable(
                name: "user_auth_providers");

            migrationBuilder.DropTable(
                name: "competition_standings");

            migrationBuilder.DropTable(
                name: "save_players");

            migrationBuilder.DropTable(
                name: "transfer_windows");

            migrationBuilder.DropTable(
                name: "season_competitions");

            migrationBuilder.DropTable(
                name: "players");

            migrationBuilder.DropTable(
                name: "save_clubs");

            migrationBuilder.DropTable(
                name: "seasons");

            migrationBuilder.DropTable(
                name: "career_saves");

            migrationBuilder.DropTable(
                name: "clubs");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "competitions");

            migrationBuilder.DropTable(
                name: "countries");
        }
    }
}
