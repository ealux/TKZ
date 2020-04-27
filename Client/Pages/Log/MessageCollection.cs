﻿namespace TKZ.Client.Pages.Log
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
        #endregion


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

        #endregion

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
        #endregion
    }
}