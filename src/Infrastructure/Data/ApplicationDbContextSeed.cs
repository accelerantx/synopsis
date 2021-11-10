using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Synopsis.Domain.Entities;

namespace Synopsis.Infrastructure.Data
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedSampleDataAsync(ApplicationDbContext context, CancellationToken cancellationToken = default)
        {
            ApplySeedData(context);
            await context.SaveChangesAsync(cancellationToken);
        }


        public static void SeedSampleData(ApplicationDbContext context)
        { 
            ApplySeedData(context);
            context.SaveChanges();
        }

        private static void ApplySeedData(ApplicationDbContext context)
        {
            if (context.Users.Any())
                return; // only seed if no users exist

            var seedDataGenerator = new SeedDataGenerator();
            seedDataGenerator.Apply(context, userCount: 20);
        }
    }

    internal class SeedDataGenerator
    {
        private readonly List<UserProfile> _users = new List<UserProfile>();
        private readonly List<Reminder> _reminders = new List<Reminder>();
        private readonly List<Tag> _tags = new List<Tag>();
        private readonly List<List> _lists = new List<List>();

        private int _reminderTagCount = 1;

        private void Generate(int userCount = 10)
        {
            for (var i = 0; i < userCount; i++)
            {
                var userId = _users.Count + 1;
                _users.Add(new UserProfile
                {
                    Id = userId,
                    Name = $"User{userId}",
                    CreateDate = DateTime.UtcNow,
                    IsDeleted = false
                });

                GenerateUserLists(userId);
                GenerateUserTags(userId);
                GenerateUserReminders(userId);
            }
        }

        private void GenerateUserTags(long userId)
        {
            for (var i = 0; i < 10; i++)
            {
                var tagId = _tags.Count + 1;
                _tags.Add(new Tag
                {
                    Id = tagId,
                    Name = $"Tag{tagId}",
                    CreateDate = DateTime.UtcNow,
                    UserId = userId,
                    IsDeleted = false
                });
            }
        }

        private void GenerateUserReminders(long userId)
        {
            foreach (var list in _lists.Where(p => p.UserId == userId))
            {
                foreach (var tag in _tags.Where(p => p.UserId == userId))
                {
                    var reminderId = _reminders.Count + 1;
                    _reminders.Add(new Reminder
                    {
                        Id = reminderId,
                        Title = $"User {userId} Reminder{reminderId}",
                        Completed = false,
                        CreateDate = DateTime.UtcNow,
                        UserId = userId,
                        ListId = list.Id,
                        Tags = new List<ReminderTag>
                        {
                            new ReminderTag
                            {
                                Id = _reminderTagCount++,
                                ReminderId = reminderId,
                                TagId = tag.Id,
                                CreateDate = DateTime.UtcNow,
                                IsDeleted = false
                            }
                        }
                    });
                }
            }
        }

        private void GenerateUserLists(int userId)
        {
            for (var i = 0; i < 5; i++)
            {
                var listId = _lists.Count + 1;
                _lists.Add(new List
                {
                    Id = _lists.Count + 1,
                    UserId = userId,
                    Name = $"List{listId}",
                    IsDeleted = false,
                    CreateDate = DateTime.UtcNow
                });
            }
        }

        public void Apply(ApplicationDbContext context, int userCount = 10)
        {
            Generate(userCount);

            context.Users.AddRange(_users);
            context.Lists.AddRange(_lists);
            context.Tags.AddRange(_tags);
            context.Reminders.AddRange(_reminders);
        }

    }
}
