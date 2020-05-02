using System.IO;

namespace TKZ.Client.Pages.Log
{
    public class MessageCollection
    {
        //
        //Nodes messages
        //

        #region Nodes

        //Nodes Duplicates
        public static Message Node_Duplicates(string nodeName)
             => new Message(MessageClass.Nodes, MessageType.Warning, $"Обнаружены дубликаты узлов!", $"Наименование узла: {nodeName}", "nodes");

        //Nodes Similar Names
        public static Message Node_SimilarNames(string nodeName)
             => new Message(MessageClass.Nodes, MessageType.Warning, $"Обнаружены узлы с одинаковыми наименованиями!", $"Наименование: {nodeName}", "nodes");

        #endregion Nodes

        //
        //Equipment messages
        //

        #region Equipment

        //Equipment Duplicates
        public static Message Equipment_Duplicates(string equipName)
             => new Message(MessageClass.Equipment, MessageType.Warning, $"Обнаружены дубликаты оборудования!", $"Наименование: {equipName}", "equip");

        //Equipment Similar Names
        public static Message Equipment_SimilarNames(string equipName)
             => new Message(MessageClass.Equipment, MessageType.Warning, $"Обнаружено оборудование с одинаковыми наименованиями!", $"Наименование: {equipName}", "equip");

        //Equipment ID
        public static Message Equipment_IdError(string equipName)
        {
            return new Message(MessageClass.Equipment, MessageType.Danger,
                               $"Отсутствует узел привязки оборудования!",
                               $"Наименование: {equipName}",
                               "equip");
        }
        #endregion Equipment

        //
        //Branches messages
        //

        #region Branches

        //Branches ID
        public static Message Branch_IdError(bool IsStartId, string branchName)
        {
            string position = IsStartId ? "начала" : "конца";
            return new Message(MessageClass.Branches, MessageType.Danger,
                               $"Отсутствует узел {position} ветви!",
                               $"Наименование ветви: {branchName}",
                               "branches");
        }

        //Branches Duplicates
        public static Message Branch_Duplicates(string branchName)
            => new Message(MessageClass.Branches, MessageType.Warning, $"Обнаружены дубликаты ветвей!", $"Наименование ветви: {branchName}", "branches");

        #endregion Branches

        //
        //Mutuals messages
        //

        #region Mutuals
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
            => new Message(MessageClass.Mutuals, MessageType.Danger, $"Пустая магнитосвязь!", $"Магнитосвязь без ветвей.", "mutual_induction");

        //Mutuals Duplicates
        public static Message Mutual_Duplicates(string startBranchName, string endBranchName)
            => new Message(MessageClass.Mutuals, MessageType.Warning, $"Обнаружены дубликаты магнитосвязей!", $"Ветвь начала: {startBranchName} Ветвь конца: {endBranchName}", "mutual_induction");
        #endregion Mutuals

        //
        //Serialization/Deserialization messages
        //

        //Serialize Successfully
        public static Message Serialize_Success(string filename)
            => new Message(MessageClass.Serialization, MessageType.Success, "Сеть успешно выгружена!", $"Файл: {filename}", "nodes");

        //Serialize Nodes Error
        #region Serialization/Deserialization
        public static Message Serialize_NodeError()
            => new Message(MessageClass.Serialization, MessageType.Danger, "Сеть не сохранена!", "Остутствуют узлы! Нечего сохранять!", "nodes");
        
        //Serialize Branches Error
        public static Message Serialize_BranchError()
            => new Message(MessageClass.Serialization, MessageType.Danger, "Сеть не сохранена!", "Остутствуют ветви! Нечего сохранять!", "branches");
        #endregion


    }
}