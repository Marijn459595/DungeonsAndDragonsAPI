using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Data_Access
{
    public class DAL : IDAL
    {
        public List<String> GetRaces()
        {
            List<String> races = new List<String>();

            SqlConnection connection = new SqlConnection(Connection.connectionString);

            connection.Open();

            string query = "SELECT [Name] FROM [Race]";
            SqlCommand getRaces = new SqlCommand(query, connection);
            SqlDataReader getRacesReader = getRaces.ExecuteReader();
            while(getRacesReader.Read())
            {
                races.Add(getRacesReader.GetString(0));
            }

            getRacesReader.Close();
            getRacesReader.Dispose();
            getRaces.Dispose();
            connection.Close();
            connection.Dispose();

            return races;
        }

        private int GetRaceID(string RaceName)
        {
            SqlConnection connection = new SqlConnection(Connection.connectionString);

            connection.Open();

            string query = "SELECT [ID] FROM [Race] WHERE [Name] = @raceName";
            SqlCommand getRaceID = new SqlCommand(query, connection);
            getRaceID.Parameters.AddWithValue("@raceName", RaceName);
            SqlDataReader getRaceIDReader = getRaceID.ExecuteReader();
            int ID = 0;
            if (getRaceIDReader.Read())
            {
                ID = getRaceIDReader.GetInt32(0);
            }

            getRaceIDReader.Close();
            getRaceIDReader.Dispose();
            getRaceID.Dispose();
            connection.Close();
            connection.Dispose();

            return ID;
        }

        public List<String> GetSubraces(string RaceName)
        {
            List<String> subraces = new List<string>();

            int ID = GetRaceID(RaceName);

            SqlConnection connection = new SqlConnection(Connection.connectionString);

            connection.Open();

            string query = "SELECT [Name] FROM [Subrace] WHERE [RaceID] = @ID";
            SqlCommand getSubraces = new SqlCommand(query, connection);
            getSubraces.Parameters.AddWithValue("@ID", ID);
            SqlDataReader getSubracesReader = getSubraces.ExecuteReader();
            while (getSubracesReader.Read())
            {
                subraces.Add(getSubracesReader.GetString(0));
            }

            getSubracesReader.Close();
            getSubracesReader.Dispose();
            getSubraces.Dispose();
            connection.Close();
            connection.Dispose();

            return subraces;
        }

        private int GetSubraceID(string SubraceName)
        {
            SqlConnection connection = new SqlConnection(Connection.connectionString);

            connection.Open();

            string query = "SELECT [ID] FROM [Subrace] WHERE [Name] = @subraceName";
            SqlCommand getSubraceID = new SqlCommand(query, connection);
            getSubraceID.Parameters.AddWithValue("@subraceName", SubraceName);
            SqlDataReader getSubraceIDReader = getSubraceID.ExecuteReader();
            int ID = 0;
            if (getSubraceIDReader.Read())
            {
                ID = getSubraceIDReader.GetInt32(0);
            }

            getSubraceIDReader.Close();
            getSubraceIDReader.Dispose();
            getSubraceID.Dispose();
            connection.Close();
            connection.Dispose();

            return ID;
        }

        public List<String> GetClasses()
        {
            List<String> classes = new List<String>();

            SqlConnection connection = new SqlConnection(Connection.connectionString);

            connection.Open();

            string query = "SELECT [Name] FROM [Class]";
            SqlCommand getClasses = new SqlCommand(query, connection);
            SqlDataReader getClassesReader = getClasses.ExecuteReader();
            while(getClassesReader.Read())
            {
                classes.Add(getClassesReader.GetString(0));
            }

            getClassesReader.Close();
            getClassesReader.Dispose();
            getClasses.Dispose();
            connection.Close();
            connection.Dispose();

            return classes;
        }

        private int GetClassID(string ClassName)
        {
            SqlConnection connection = new SqlConnection(Connection.connectionString);

            connection.Open();

            string query = "SELECT [ID] FROM [Class] WHERE [Name] = @className";
            SqlCommand getClassID = new SqlCommand(query, connection);
            getClassID.Parameters.AddWithValue("@className", ClassName);
            SqlDataReader getClassIDReader = getClassID.ExecuteReader();
            int ID = 0;
            if(getClassIDReader.Read())
            {
                ID = getClassIDReader.GetInt32(0);
            }
            
            getClassIDReader.Close();
            getClassIDReader.Dispose();
            getClassID.Dispose();
            connection.Close();
            connection.Dispose();

            return ID;
        }

        public List<String> GetSubclasses(string ClassName)
        {
            List<String> subclasses = new List<string>();

            int ID = GetClassID(ClassName);

            SqlConnection connection = new SqlConnection(Connection.connectionString);

            connection.Open();

            string query = "SELECT [Name] FROM [Subclass] WHERE [ClassID] = @ID";
            SqlCommand getSubclasses = new SqlCommand(query, connection);
            getSubclasses.Parameters.AddWithValue("@ID", ID);
            SqlDataReader getSubclassesReader = getSubclasses.ExecuteReader();
            while(getSubclassesReader.Read())
            {
                subclasses.Add(getSubclassesReader.GetString(0));
            }

            getSubclassesReader.Close();
            getSubclassesReader.Dispose();
            getSubclasses.Dispose();
            connection.Close();
            connection.Dispose();

            return subclasses;
        }

        private int GetSubclassID(string SubclassName)
        {
            SqlConnection connection = new SqlConnection(Connection.connectionString);

            connection.Open();

            string query = "SELECT [ID] FROM [Subclass] WHERE [Name] = @subclassName";
            SqlCommand getSubclassID = new SqlCommand(query, connection);
            getSubclassID.Parameters.AddWithValue("@subclassName", SubclassName);
            SqlDataReader getSubclassIDReader = getSubclassID.ExecuteReader();
            int ID = 0;
            if (getSubclassIDReader.Read())
            {
                ID = getSubclassIDReader.GetInt32(0);
            }

            getSubclassIDReader.Close();
            getSubclassIDReader.Dispose();
            getSubclassID.Dispose();
            connection.Close();
            connection.Dispose();

            return ID;
        }

        public List<Ability> GetAbilities(string RaceName, string ClassName, string SubraceName, string SubclassName)
        {
            List<Ability> abilities = new List<Ability>();

            int raceID = GetRaceID(RaceName);
            int classID = GetClassID(ClassName);
            int subraceID = GetSubraceID(SubraceName);
            int subclassID = GetSubclassID(SubclassName);

            SqlConnection connection = new SqlConnection(Connection.connectionString);

            connection.Open();

            string query = "SELECT [UnlockLevel], [TraitID] FROM [TraitUnlock] WHERE [RaceID] = @raceID OR [ClassID] = @classID OR [SubraceID] = @subraceID OR [SubclassID] = @subclassID";
            SqlCommand getAbilities = new SqlCommand(query, connection);
            getAbilities.Parameters.AddWithValue("@raceID", raceID);
            getAbilities.Parameters.AddWithValue("@classID", classID);
            getAbilities.Parameters.AddWithValue("@subraceID", subraceID);
            getAbilities.Parameters.AddWithValue("@subclassID", subclassID);
            SqlDataReader getAbilitiesReader = getAbilities.ExecuteReader();
            while (getAbilitiesReader.Read())
            {
                abilities.Add(new Ability(getAbilitiesReader.GetInt32(0), getAbilitiesReader.GetInt32(1)));
            }

            getAbilitiesReader.Close();
            getAbilitiesReader.Dispose();
            getAbilities.Dispose();

            foreach (var ability in abilities)
            {
                query = "SELECT [Name], [Description] FROM [Trait] WHERE [ID] = @ID";
                SqlCommand getAbility = new SqlCommand(query, connection);
                getAbility.Parameters.AddWithValue("@ID", ability.ID);
                SqlDataReader getAbilityReader = getAbility.ExecuteReader();
                if (getAbilityReader.Read())
                {
                    ability.SetAbility(getAbilityReader.GetString(0), getAbilityReader.GetString(1));
                }

                getAbilityReader.Close();
                getAbilityReader.Dispose();
                getAbility.Dispose();
            }

            connection.Close();
            connection.Dispose();

            return abilities;
        }

        public List<String> GetProficiencies(string className)
        {
            List<String> proficiencies = new List<String>();

            int classID = GetClassID(className);

            SqlConnection connection = new SqlConnection(Connection.connectionString);

            connection.Open();

            string query = "SELECT [SkillID] FROM [SkillProficiencies] WHERE [ClassID] = @ID";
            SqlCommand getProficiencyIDs = new SqlCommand(query, connection);
            getProficiencyIDs.Parameters.AddWithValue("@ID", classID);
            SqlDataReader getProficiencyIDsReader = getProficiencyIDs.ExecuteReader();
            List<int> proficiencyIDs = new List<int>();
            while (getProficiencyIDsReader.Read())
            {
                proficiencyIDs.Add(getProficiencyIDsReader.GetInt32(0));
            }

            getProficiencyIDsReader.Close();
            getProficiencyIDsReader.Dispose();
            getProficiencyIDs.Dispose();

            foreach (int proficiencyID in proficiencyIDs)
            {
                query = "SELECT [Skill] FROM [Skill] WHERE [ID] = @ID";
                SqlCommand getProficiency = new SqlCommand(query, connection);
                getProficiency.Parameters.AddWithValue("@ID", proficiencyID);
                SqlDataReader getProficiencyReader = getProficiency.ExecuteReader();
                if (getProficiencyReader.Read())
                {
                    proficiencies.Add(getProficiencyReader.GetString(0));
                }

                getProficiencyReader.Close();
                getProficiencyReader.Dispose();
                getProficiency.Dispose();
            }

            connection.Close();
            connection.Dispose();

            return proficiencies;
        }

        public int GetProficiencyAmount(string className)
        {
            int classID = GetClassID(className);

            SqlConnection connection = new SqlConnection(Connection.connectionString);

            connection.Open();

            string query = "SELECT [Proficiencies] FROM [Class] WHERE [ID] = @ID";
            SqlCommand getProficiencyAmount = new SqlCommand(query, connection);
            getProficiencyAmount.Parameters.AddWithValue("@ID", classID);
            SqlDataReader getProficiencyAmountReader = getProficiencyAmount.ExecuteReader();
            int proficiencyAmount = 0;
            if (getProficiencyAmountReader.Read())
            {
                proficiencyAmount = getProficiencyAmountReader.GetInt32(0);
            }
            getProficiencyAmountReader.Close();
            getProficiencyAmountReader.Dispose();
            getProficiencyAmount.Dispose();

            connection.Close();
            connection.Dispose();

            return proficiencyAmount;
        }
    }
}
