using Bazzigg.Database.Entity;
using Bazzigg.Database.Model.Match;

using Kartrider.Api.Endpoints.MatchEndpoint.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Bazzigg.Database.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<PlayerDetail> PlayerDetail { get; set; }
        public DbSet<PlayerSummary> PlayerSummary { get; set; }
        public DbSet<TrackRecord> TrackRecord { get; set; }
        public DbSet<Influencer> Influencer { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecentTrackSummary>(eb =>
            {
                eb.ToTable("recent_track_summary");

                eb.Property<Guid>("Id")
                .ValueGeneratedOnAdd();

                eb.Property(p => p.Track)
                .HasMaxLength(30)
                .IsRequired();

                eb.Property(p => p.TrackHash)
                .HasMaxLength(65)
                .IsRequired();

                eb.Property(p => p.Lose)
                .HasColumnType("SMALLINT")
                .IsRequired();

                eb.Property(p => p.Win)
                .HasColumnType("SMALLINT")
                .IsRequired();

                eb.Property(p => p.WinningRate)
                .HasColumnType("FLOAT")
                .IsRequired();

                eb.Property(p => p.TrackPlayCount)
                .HasColumnType("SMALLINT")
                .IsRequired();

                eb.Property(p => p.Top)
                .HasColumnType("FLOAT")
                .IsRequired();


            });
            modelBuilder.Entity<MatchPreview>(eb =>
            {
                eb.ToTable("match_preview");

                eb.Property<Guid>("Id")
                .ValueGeneratedOnAdd();

                eb.Property(p => p.MatchId)
                // example: 0353000e34f8ca42, 사이즈 16
                .HasMaxLength(17)
                // 혹시 모르니까 + 1
                .IsRequired();

                eb.Property(p => p.Rank)
                .HasColumnType("TINYINT")
                .IsRequired();

                eb.Property(p => p.Track)
                // 67b33be0a18d7a045a6f1a4607b63ba90effad6a075f3238a2e4d098dd123805, 사이즈 64
                .HasMaxLength(65)
                // 혹시 모르니까 + 1
                .IsRequired();

                eb.Property(p => p.Kartbody)
                .HasMaxLength(20)
                .IsRequired();

                eb.Property(p => p.KartbodyHash)
                .HasMaxLength(65)
                .IsRequired();

                eb.Property(p => p.Character)
                .HasMaxLength(20)
                .IsRequired();

                eb.Property(p => p.CharacterHash)
                .HasMaxLength(65)
                .IsRequired();

                eb.Property(p => p.Record)
                .IsRequired();
            });
            modelBuilder.Entity<PlayerDetail>(eb =>
            {
                eb.ToTable("player_details");

                eb.Property(p => p.AccessId)
                .IsRequired();

                eb.Property(p => p.Channel)
                .HasMaxLength(50)
                // 넉넉하게
                .IsRequired();

                eb.Property(p => p.RacingMasterEmblem)
                .IsRequired();

                eb.Property(p => p.License)
                .HasDefaultValue(License.Unknown)
                .HasColumnType("TINYINT")
                .IsRequired();

                eb.Property(p => p.LastRenewal)
                .IsRequired();

                eb.Property(p => p.Nickname)
                .HasMaxLength(12)
                .IsRequired();

                eb.HasKey(p => new { p.AccessId, p.Channel });

                eb.HasMany(p => p.RecentTrackRecords)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

                eb.HasMany(p => p.Matches)
                .WithOne()
                .IsRequired();
                //IsRequired시 자동으로 OnDelete(DeleteBehavior.Cascade) 설정됨

                eb.OwnsOne(p => p.RecentMatchSummary);



            });

            modelBuilder.Entity<PlayerSummary>(eb =>
            {
                eb.ToTable("player_summary");
                eb.HasKey(p => p.Nickname);

                eb.Property(p => p.Nickname)
                .HasMaxLength(12)
                .IsRequired();

                eb.Property(p => p.CharacterHash)
                .HasMaxLength(65)
                .IsRequired();
            });

            modelBuilder.Entity<TrackRecord>(eb =>
            {
                eb.ToTable("track_record");
                eb.HasKey(p => new { p.Channel, p.TrackId });

                eb.Property(p => p.Records)
                .HasConversion(v => JsonSerializer.Serialize(v, null), v => JsonSerializer.Deserialize<List<double>>(v, null))
                .IsRequired();

                var valueComparer = new ValueComparer<List<double>>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToList());
                eb.Property(p => p.Records).Metadata.SetValueComparer(valueComparer);
            });

            modelBuilder.Entity<Influencer>(eb =>
            {
                eb.Property(p => p.AccessId).IsRequired();
                eb.Property(p => p.Nickname).IsRequired();
                eb.Property(p => p.Description).IsRequired();
                eb.Property(p => p.Keywords)
                    .HasConversion(
                        v => JsonSerializer.Serialize(v,null),
                        v => JsonSerializer.Deserialize<List<string>>(v,null));
                eb.Property<Guid>("Id")
                .ValueGeneratedOnAdd();
            });
        }
    }
}
