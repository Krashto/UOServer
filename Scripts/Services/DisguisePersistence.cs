#region References
using System.IO;
using System.Linq;
#endregion

namespace Server.Items
{
    public static class DisguisePersistence
    {
        private static readonly string FilePath = Path.Combine("Saves", "Disguises", "Persistence.bin");

        public static void Configure()
        {
   //         EventSink.WorldSave += OnSave;
   //         EventSink.WorldLoad += OnLoad;
        }

        private static void OnSave(WorldSaveEventArgs e)
        {
            Persistence.Serialize(
                FilePath,
                writer =>
                {
                    writer.Write(0); // version

  /*                  writer.Write(DisguiseTimers.Timers.Count);

                    foreach (Mobile m in DisguiseTimers.Timers.Keys.OfType<Mobile>())
                    {
                        writer.Write(m);
                        writer.Write(DisguiseTimers.TimeRemaining(m));
                        writer.Write(m.NameMod);
                    }*/
                });
        }

        private static void OnLoad()
        {
            Persistence.Deserialize(
                FilePath,
                reader =>
                {
             /*       int version = reader.ReadInt();

                    switch (version)
                    {
                        case 0:
                            {
                                int count = reader.ReadInt();

                                for (int i = 0; i < count; ++i)
                                {
                                    Mobile m = reader.ReadMobile();
                                    DisguiseTimers.CreateTimer(m, reader.ReadTimeSpan());
                                    m.NameMod = reader.ReadString();
                                }
                            }
                            break;
                    }*/
                });
        }
    }
}
