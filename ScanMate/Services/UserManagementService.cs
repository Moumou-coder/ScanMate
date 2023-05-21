namespace ScanMate.Services;


public partial class UserManagementService
{
    public UserManagementService()
    {
        if (Globals.UserSet.Tables.Contains("Users"))
        {

            if (Globals.UserSet.Tables["Users"].Constraints.Contains("Access2User"))
            {
                Globals.UserSet.Tables["Users"].Constraints.Remove("Access2User");
            }
            // Supprimer les relations associées à la DataTable
            List<DataRelation> relationsToRemove = new List<DataRelation>();
            foreach (DataRelation relation in Globals.UserSet.Relations)
            {
                if (relation.ParentTable == Globals.UserSet.Tables["Users"] || relation.ChildTable == Globals.UserSet.Tables["Users"])
                {
                    relationsToRemove.Add(relation);
                }
            }
            foreach (DataRelation relationToRemove in relationsToRemove)
            {
                Globals.UserSet.Relations.Remove(relationToRemove);
            }

            // Supprimer la DataTable existante
            Globals.UserSet.Tables.Remove("Users");
        }
        if (Globals.UserSet.Tables.Contains("Access"))
        {

            if (Globals.UserSet.Tables["Access"].Constraints.Contains("Access2User"))
            {
                Globals.UserSet.Tables["Access"].Constraints.Remove("Access2User");
            }
            // Supprimer les relations associées à la DataTable
            List<DataRelation> relationsToRemove = new List<DataRelation>();
            foreach (DataRelation relation in Globals.UserSet.Relations)
            {
                if (relation.ParentTable == Globals.UserSet.Tables["Access"] || relation.ChildTable == Globals.UserSet.Tables["Access"])
                {
                    relationsToRemove.Add(relation);
                }
            }
            foreach (DataRelation relationToRemove in relationsToRemove)
            {
                Globals.UserSet.Relations.Remove(relationToRemove);
            }

            // Supprimer la DataTable existante
            Globals.UserSet.Tables.Remove("Access");
        }
        DataTable existingTable = Globals.UserSet.Tables["Users"];
        if (existingTable == null)
        {
            //create tables for DB
            DataTable UserTable = new();
            DataTable AccessTable = new();

            //create columns for the DB Users with the same names between the parentheses
            DataColumn User_ID = new DataColumn("User_ID", System.Type.GetType("System.Int16"));
            DataColumn UserName = new DataColumn("UserName", System.Type.GetType("System.String"));
            DataColumn UserPassword = new DataColumn("UserPassword", System.Type.GetType("System.String"));
            DataColumn UserAccessType = new DataColumn("UserAccessType", System.Type.GetType("System.Int16"));

            //create columns for the DB Access with the same names between the parentheses
            DataColumn Access_ID = new DataColumn("Access_ID", System.Type.GetType("System.Int16"));
            DataColumn AccessName = new DataColumn("AccessName", System.Type.GetType("System.String"));
            DataColumn CreateObject = new DataColumn("CreateObject", System.Type.GetType("System.Boolean"));
            DataColumn DestroyObject = new DataColumn("DestroyObject", System.Type.GetType("System.Boolean"));
            DataColumn ModifyObject = new DataColumn("ModifyObject", System.Type.GetType("System.Boolean"));
            DataColumn ChangeUserRights = new DataColumn("ChangeUserRights", System.Type.GetType("System.Boolean"));

            //UserTable
            UserTable.TableName = "Users";

            User_ID.AutoIncrement = true;
            User_ID.Unique = true;
            UserTable.Columns.Add(User_ID);

            UserName.Unique = true;
            UserTable.Columns.Add(UserName);

            UserTable.Columns.Add(UserPassword);

            UserTable.Columns.Add(UserAccessType);

            //AccessTable
            AccessTable.TableName = "Access";

            Access_ID.AutoIncrement = true;
            Access_ID.Unique = true;
            AccessTable.Columns.Add(Access_ID);

            AccessName.Unique = true;
            AccessTable.Columns.Add(AccessName);

            AccessTable.Columns.Add(CreateObject);

            AccessTable.Columns.Add(DestroyObject);

            AccessTable.Columns.Add(ModifyObject);

            AccessTable.Columns.Add(ChangeUserRights);

            //DataSet
            Globals.UserSet.Tables.Add(UserTable);
            Globals.UserSet.Tables.Add(AccessTable);

            DataColumn parentColumn = Globals.UserSet.Tables["Access"].Columns["Access_ID"];
            DataColumn childColumn = Globals.UserSet.Tables["Users"].Columns["UserAccessType"];

            DataRelation relation = new DataRelation("Access2User", parentColumn, childColumn);

            Globals.UserSet.Tables["Users"].ParentRelations.Add(relation);
        }
        else
        {
            // Utiliser la DataTable existante
            DataTable UserTable = existingTable;
        }
       
    }
}




