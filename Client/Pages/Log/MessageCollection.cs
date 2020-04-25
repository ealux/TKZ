namespace TKZ.Client.Pages.Log
{
    public class MessageCollection
    {
        //
        //Branches messages
        //
        //Branches ID
        public static Message Branch_IdError(bool IsStartId, string branchName)
        {
            string position = IsStartId ? "начала" : "конца";
            return new Message(MessageClass.Branches, MessageType.Danger,
                               $"Отсутствует узел {position} ветви!",
                               $"Наименование ветви: {branchName}",
                               "branches");
        }

        //
        //Mutuals messages
        //
        //Mutuals ID
        public static Message Mutual_IdError(bool IsStartId, string restBranchName)
        {
            string position = IsStartId ? "начала" : "конца";
            return new Message(MessageClass.Mutuals, MessageType.Danger,
                               $"Отсутствует ветвь {position} магнитосвязи!",
                               $"Магнитосвязь ветви: {restBranchName}",
                               "mutual_induction");
        }

        //Mutuals Orphan
        public static Message Mutual_OrphanError()
        {
            return new Message(MessageClass.Mutuals, MessageType.Danger,
                               $"Пустая магнитосвязь!",
                               $"Магнитосвязь без ветвей.",
                               "mutual_induction");
        }
    }
}