﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WhatToStreamBackend.Models.Db;

#nullable disable

namespace WhatToStreamBackend.Migrations
{
    [DbContext(typeof(ShowsDbContext))]
    [Migration("20240701230359_AddRuntimeRemoveUnusedId")]
    partial class AddRuntimeRemoveUnusedId
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WhatToStreamBackend.Models.Db.Country", b =>
                {
                    b.Property<string>("CountryCode")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("CountryCode");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            CountryCode = "dk",
                            Name = "Denmark"
                        },
                        new
                        {
                            CountryCode = "gb",
                            Name = "United Kingdom"
                        },
                        new
                        {
                            CountryCode = "us",
                            Name = "United States"
                        },
                        new
                        {
                            CountryCode = "jp",
                            Name = "Japan"
                        },
                        new
                        {
                            CountryCode = "kr",
                            Name = "South Korea"
                        },
                        new
                        {
                            CountryCode = "se",
                            Name = "Sweden"
                        });
                });

            modelBuilder.Entity("WhatToStreamBackend.Models.Db.Genre", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = "action",
                            Name = "Action"
                        },
                        new
                        {
                            Id = "adventure",
                            Name = "Adventure"
                        },
                        new
                        {
                            Id = "animation",
                            Name = "Animation"
                        },
                        new
                        {
                            Id = "comedy",
                            Name = "Comedy"
                        },
                        new
                        {
                            Id = "crime",
                            Name = "Crime"
                        },
                        new
                        {
                            Id = "documentary",
                            Name = "Documentary"
                        },
                        new
                        {
                            Id = "drama",
                            Name = "Drama"
                        },
                        new
                        {
                            Id = "family",
                            Name = "Family"
                        },
                        new
                        {
                            Id = "fantasy",
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = "history",
                            Name = "History"
                        },
                        new
                        {
                            Id = "horror",
                            Name = "Horror"
                        },
                        new
                        {
                            Id = "music",
                            Name = "Music"
                        },
                        new
                        {
                            Id = "mystery",
                            Name = "Mystery"
                        },
                        new
                        {
                            Id = "news",
                            Name = "News"
                        },
                        new
                        {
                            Id = "reality",
                            Name = "Reality"
                        },
                        new
                        {
                            Id = "romance",
                            Name = "Romance"
                        },
                        new
                        {
                            Id = "scifi",
                            Name = "Science Fiction"
                        },
                        new
                        {
                            Id = "talk",
                            Name = "Talk Show"
                        },
                        new
                        {
                            Id = "thriller",
                            Name = "Thriller"
                        },
                        new
                        {
                            Id = "war",
                            Name = "War"
                        },
                        new
                        {
                            Id = "western",
                            Name = "Western"
                        });
                });

            modelBuilder.Entity("WhatToStreamBackend.Models.Db.HorizontalImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("W1080")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasAnnotation("Relational:JsonPropertyName", "w1080");

                    b.Property<string>("W1440")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasAnnotation("Relational:JsonPropertyName", "w1440");

                    b.Property<string>("W360")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasAnnotation("Relational:JsonPropertyName", "w360");

                    b.Property<string>("W480")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasAnnotation("Relational:JsonPropertyName", "w480");

                    b.Property<string>("W720")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasAnnotation("Relational:JsonPropertyName", "w720");

                    b.HasKey("Id");

                    b.ToTable("HorizontalImages");

                    b.HasAnnotation("Relational:JsonPropertyName", "horizontalPoster");
                });

            modelBuilder.Entity("WhatToStreamBackend.Models.Db.ServiceImageSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DarkThemeImage")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasAnnotation("Relational:JsonPropertyName", "darkThemeImage");

                    b.Property<string>("LightThemeImage")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasAnnotation("Relational:JsonPropertyName", "lightThemeImage");

                    b.Property<string>("WhiteImage")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasAnnotation("Relational:JsonPropertyName", "whiteImage");

                    b.HasKey("Id");

                    b.ToTable("ServiceImageSets");

                    b.HasAnnotation("Relational:JsonPropertyName", "imageSet");
                });

            modelBuilder.Entity("WhatToStreamBackend.Models.Db.ServiceInfo", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<string>("HomePage")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasAnnotation("Relational:JsonPropertyName", "homePage");

                    b.Property<int?>("ImageSetId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.Property<string>("ThemeColorCode")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasAnnotation("Relational:JsonPropertyName", "themeColorCode");

                    b.HasKey("Id");

                    b.HasIndex("ImageSetId");

                    b.ToTable("ServiceInfos");

                    b.HasAnnotation("Relational:JsonPropertyName", "streamingService");

                    b.HasData(
                        new
                        {
                            Id = "apple",
                            HomePage = "https://tv.apple.com",
                            Name = "Apple TV",
                            ThemeColorCode = "#000000"
                        },
                        new
                        {
                            Id = "netflix",
                            HomePage = "https://netflix.com",
                            Name = "Netflix",
                            ThemeColorCode = "#E50914"
                        },
                        new
                        {
                            Id = "prime",
                            HomePage = "https://www.primevideo.com/",
                            Name = "Prime Video",
                            ThemeColorCode = "#00A8E1"
                        },
                        new
                        {
                            Id = "disney",
                            HomePage = "https://www.disneyplus.com/",
                            Name = "Disney+",
                            ThemeColorCode = "#01137c"
                        });
                });

            modelBuilder.Entity("WhatToStreamBackend.Models.Db.Show", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<int?>("EpisodeCount")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "episodeCount");

                    b.Property<int?>("FirstAirYear")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "firstAirYear");

                    b.Property<int?>("ImageSetId")
                        .HasColumnType("int");

                    b.Property<string>("ImdbId")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasAnnotation("Relational:JsonPropertyName", "imdbId");

                    b.Property<string>("ItemType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasAnnotation("Relational:JsonPropertyName", "itemType");

                    b.Property<int?>("LastAirYear")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "lastAirYear");

                    b.Property<string>("OriginalTitle")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)")
                        .HasAnnotation("Relational:JsonPropertyName", "originalTitle");

                    b.Property<string>("Overview")
                        .HasMaxLength(8000)
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "overview");

                    b.Property<int?>("Rating")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "rating");

                    b.Property<int?>("ReleaseYear")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "releaseYear");

                    b.Property<int?>("Runtime")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "runtime");

                    b.Property<int?>("SeasonCount")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "seasonCount");

                    b.Property<string>("ShowType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasAnnotation("Relational:JsonPropertyName", "showType");

                    b.Property<string>("Title")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)")
                        .HasAnnotation("Relational:JsonPropertyName", "title");

                    b.Property<string>("TmdbId")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasAnnotation("Relational:JsonPropertyName", "tmdbId");

                    b.HasKey("Id");

                    b.HasIndex("ImageSetId");

                    b.ToTable("Shows");

                    b.HasData(
                        new
                        {
                            Id = "66",
                            ImdbId = "tt0111161",
                            ItemType = "show",
                            OriginalTitle = "The Shawshank Redemption",
                            Overview = "Red (Morgan Freeman) and Andy (Tim Robbins), both incarcerated at Shawshank prison, forge an unlikely bond that will span more than twenty years. Together they discover hope as the ultimate means of survival, in a poignant tale of the human spirit.",
                            Rating = 90,
                            ReleaseYear = 1994,
                            ShowType = "movie",
                            Title = "The Shawshank Redemption",
                            TmdbId = "movie/278"
                        },
                        new
                        {
                            Id = "968",
                            EpisodeCount = 12,
                            FirstAirYear = 2022,
                            ImdbId = "tt14169960",
                            ItemType = "show",
                            LastAirYear = 2022,
                            OriginalTitle = "지금 우리 학교는",
                            Overview = "A high school becomes ground zero for a zombie virus outbreak. Trapped students must fight their way out — or turn into one of the rabid infected.",
                            Rating = 76,
                            SeasonCount = 2,
                            ShowType = "series",
                            Title = "All of Us Are Dead",
                            TmdbId = "tv/99966"
                        });
                });

            modelBuilder.Entity("WhatToStreamBackend.Models.Db.ShowGenre", b =>
                {
                    b.Property<string>("ShowId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnOrder(0)
                        .HasAnnotation("Relational:JsonPropertyName", "showId");

                    b.Property<string>("GenreId")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnOrder(1)
                        .HasAnnotation("Relational:JsonPropertyName", "genreId");

                    b.HasKey("ShowId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("ShowGenres");

                    b.HasAnnotation("Relational:JsonPropertyName", "genres");

                    b.HasData(
                        new
                        {
                            ShowId = "66",
                            GenreId = "drama"
                        },
                        new
                        {
                            ShowId = "968",
                            GenreId = "drama"
                        },
                        new
                        {
                            ShowId = "968",
                            GenreId = "action"
                        },
                        new
                        {
                            ShowId = "968",
                            GenreId = "fantasy"
                        });
                });

            modelBuilder.Entity("WhatToStreamBackend.Models.Db.ShowImageSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("HorizontalBackdropId")
                        .HasColumnType("int");

                    b.Property<int?>("HorizontalPosterId")
                        .HasColumnType("int");

                    b.Property<int?>("VerticalBackdropId")
                        .HasColumnType("int");

                    b.Property<int?>("VerticalPosterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HorizontalBackdropId");

                    b.HasIndex("HorizontalPosterId");

                    b.HasIndex("VerticalBackdropId");

                    b.HasIndex("VerticalPosterId");

                    b.ToTable("ShowImageSets");

                    b.HasAnnotation("Relational:JsonPropertyName", "imageSet");
                });

            modelBuilder.Entity("WhatToStreamBackend.Models.Db.StreamingOption", b =>
                {
                    b.Property<string>("ShowId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnOrder(0)
                        .HasAnnotation("Relational:JsonPropertyName", "showId");

                    b.Property<string>("ServiceId")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnOrder(1)
                        .HasAnnotation("Relational:JsonPropertyName", "serviceId");

                    b.Property<string>("CountryCode")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)")
                        .HasColumnOrder(2)
                        .HasAnnotation("Relational:JsonPropertyName", "countryCode");

                    b.Property<long?>("AvailableSince")
                        .HasColumnType("bigint")
                        .HasAnnotation("Relational:JsonPropertyName", "availableSince");

                    b.Property<long?>("ExpiresOn")
                        .HasColumnType("bigint")
                        .HasAnnotation("Relational:JsonPropertyName", "expiresOn");

                    b.Property<bool?>("ExpiresSoon")
                        .HasColumnType("bit")
                        .HasAnnotation("Relational:JsonPropertyName", "expiresSoon");

                    b.Property<string>("Link")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasAnnotation("Relational:JsonPropertyName", "link");

                    b.Property<string>("Quality")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasAnnotation("Relational:JsonPropertyName", "quality");

                    b.Property<string>("Type")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasAnnotation("Relational:JsonPropertyName", "type");

                    b.Property<string>("VideoLink")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasAnnotation("Relational:JsonPropertyName", "videoLink");

                    b.HasKey("ShowId", "ServiceId", "CountryCode");

                    b.HasIndex("CountryCode");

                    b.HasIndex("ServiceId");

                    b.ToTable("StreamingOptions");

                    b.HasAnnotation("Relational:JsonPropertyName", "streamingOptions");

                    b.HasData(
                        new
                        {
                            ShowId = "66",
                            ServiceId = "netflix",
                            CountryCode = "dk"
                        },
                        new
                        {
                            ShowId = "66",
                            ServiceId = "netflix",
                            CountryCode = "us"
                        },
                        new
                        {
                            ShowId = "66",
                            ServiceId = "disney",
                            CountryCode = "us"
                        },
                        new
                        {
                            ShowId = "968",
                            ServiceId = "netflix",
                            CountryCode = "dk",
                            AvailableSince = 1693809875L,
                            ExpiresSoon = false,
                            Link = "https://www.netflix.com/title/81237994/"
                        },
                        new
                        {
                            ShowId = "968",
                            ServiceId = "netflix",
                            CountryCode = "us",
                            AvailableSince = 1648576144L,
                            ExpiresSoon = true,
                            Link = "https://www.netflix.com/title/81237994/"
                        });
                });

            modelBuilder.Entity("WhatToStreamBackend.Models.Db.VerticalImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("W240")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasAnnotation("Relational:JsonPropertyName", "w240");

                    b.Property<string>("W360")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasAnnotation("Relational:JsonPropertyName", "w360");

                    b.Property<string>("W480")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasAnnotation("Relational:JsonPropertyName", "w480");

                    b.Property<string>("W600")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasAnnotation("Relational:JsonPropertyName", "w600");

                    b.Property<string>("W720")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasAnnotation("Relational:JsonPropertyName", "w720");

                    b.HasKey("Id");

                    b.ToTable("VerticalImages");

                    b.HasAnnotation("Relational:JsonPropertyName", "verticalPoster");
                });

            modelBuilder.Entity("WhatToStreamBackend.Models.Db.ServiceInfo", b =>
                {
                    b.HasOne("WhatToStreamBackend.Models.Db.ServiceImageSet", "ImageSet")
                        .WithMany()
                        .HasForeignKey("ImageSetId");

                    b.Navigation("ImageSet");
                });

            modelBuilder.Entity("WhatToStreamBackend.Models.Db.Show", b =>
                {
                    b.HasOne("WhatToStreamBackend.Models.Db.ShowImageSet", "ImageSet")
                        .WithMany()
                        .HasForeignKey("ImageSetId");

                    b.Navigation("ImageSet");
                });

            modelBuilder.Entity("WhatToStreamBackend.Models.Db.ShowGenre", b =>
                {
                    b.HasOne("WhatToStreamBackend.Models.Db.Genre", "Genre")
                        .WithMany("ShowGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WhatToStreamBackend.Models.Db.Show", "Show")
                        .WithMany("ShowGenres")
                        .HasForeignKey("ShowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Show");
                });

            modelBuilder.Entity("WhatToStreamBackend.Models.Db.ShowImageSet", b =>
                {
                    b.HasOne("WhatToStreamBackend.Models.Db.HorizontalImage", "HorizontalBackdrop")
                        .WithMany()
                        .HasForeignKey("HorizontalBackdropId");

                    b.HasOne("WhatToStreamBackend.Models.Db.HorizontalImage", "HorizontalPoster")
                        .WithMany()
                        .HasForeignKey("HorizontalPosterId");

                    b.HasOne("WhatToStreamBackend.Models.Db.VerticalImage", "VerticalBackdrop")
                        .WithMany()
                        .HasForeignKey("VerticalBackdropId");

                    b.HasOne("WhatToStreamBackend.Models.Db.VerticalImage", "VerticalPoster")
                        .WithMany()
                        .HasForeignKey("VerticalPosterId");

                    b.Navigation("HorizontalBackdrop");

                    b.Navigation("HorizontalPoster");

                    b.Navigation("VerticalBackdrop");

                    b.Navigation("VerticalPoster");
                });

            modelBuilder.Entity("WhatToStreamBackend.Models.Db.StreamingOption", b =>
                {
                    b.HasOne("WhatToStreamBackend.Models.Db.Country", "Country")
                        .WithMany("StreamingOptions")
                        .HasForeignKey("CountryCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WhatToStreamBackend.Models.Db.ServiceInfo", "StreamingService")
                        .WithMany("StreamingOptions")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WhatToStreamBackend.Models.Db.Show", "Show")
                        .WithMany("StreamingOptions")
                        .HasForeignKey("ShowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("Show");

                    b.Navigation("StreamingService");
                });

            modelBuilder.Entity("WhatToStreamBackend.Models.Db.Country", b =>
                {
                    b.Navigation("StreamingOptions");
                });

            modelBuilder.Entity("WhatToStreamBackend.Models.Db.Genre", b =>
                {
                    b.Navigation("ShowGenres");
                });

            modelBuilder.Entity("WhatToStreamBackend.Models.Db.ServiceInfo", b =>
                {
                    b.Navigation("StreamingOptions");
                });

            modelBuilder.Entity("WhatToStreamBackend.Models.Db.Show", b =>
                {
                    b.Navigation("ShowGenres");

                    b.Navigation("StreamingOptions");
                });
#pragma warning restore 612, 618
        }
    }
}
