using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using Controller.Clinic;
using Controller.Employees;
using Dao.Clinic.CSVImpl;
using Manager.Model;
using Klinika.Database.Csv.Stream;
using Klinika.Database.Csv.Converter.Clinic;
using Dao.Employees.CSVImpl;
using Service.Clinic;
using Service.Employees;
using Model.Manager;
using Klinika.Database.Sequencer;
using Klinika.Database.Csv.Converter.Employees;
using System.Security;

namespace Manager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string FUNC_DB = "..\\..\\..\\..\\Klinika\\Resources\\FunctionalityDB.csv";
        private const string DEPT_DB = "..\\..\\..\\..\\Klinika\\Resources\\DepatrmentDB.csv";
        private const string INGREDIENT_DB = "..\\..\\..\\..\\Klinika\\Resources\\IngredientDB.csv";
        private const string MEDICINE_DB = "..\\..\\..\\..\\Klinika\\Resources\\MedicineDB.csv";
        private const string RECOVERYROOM_DB = "..\\..\\..\\..\\Klinika\\Resources\\RecoveryRoomDB.csv";
        private const string RENOVATION_DB = "..\\..\\..\\..\\Klinika\\Resources\\RenovationDB.csv";
        private const string RENOVATIONRESULT_DB = "..\\..\\..\\..\\Klinika\\Resources\\RenovationResultDB.csv";
        private const string ROOM_DB = "..\\..\\..\\..\\Klinika\\Resources\\RoomDB.csv";
        private const string EQUIPMENT_DB = "..\\..\\..\\..\\Klinika\\Resources\\EquipmentDB.csv";
        
        private const string SHIFT_DB = "..\\..\\..\\..\\Klinika\\Resources\\ShiftDB.csv";
        private const string WORKTIME_DB = "..\\..\\..\\..\\Klinika\\Resources\\WorkTimeDB.csv";

        private const string CSV_DELIMITER = ",";

        public const string UNDEFINED_FUNC = "Nedefinisana";
        private const string STORAGE_FUNC = "Magacin";
        private const string EXAMINATION_FUNC = "Za preglede";
        private const string OPERATION_FUNC = "Operaciona sala";
        private const string RECOVERYROOM_FUNC = "Soba za lezanje";

        public const string UNDEFINED_DEPT = "Nedefinisan";
        private const string STORAGE_DEPT = "Magacin";

        public App()
        {
            //DAO
            var funcDao = new RoomFuncDao(new CSVStream<Functionality>(FUNC_DB, new FunctionalityCSVConverter(CSV_DELIMITER)), new LongSequencer());
            var deptDao = new RoomDepartmentDao(new CSVStream<Department>(DEPT_DB, new DepartmentCSVConverter(CSV_DELIMITER)), new LongSequencer());
            var ingredientDao = new IngredientDao(
                new CSVStream<Ingredient>(INGREDIENT_DB, new IngredientCSVConverter(CSV_DELIMITER)), new LongSequencer());
            var medicineDao = new MedicineDao(new CSVStream<Medicine>(MEDICINE_DB, new MedicineCSVConverter(CSV_DELIMITER)));
            var recoveryRoomDao = new RecoveryRoomDao(
                new CSVStream<RecoveryRoom>(RECOVERYROOM_DB, new RecoveryRoomCSVConverter(CSV_DELIMITER)));
            var renovationDao = new RenovationDao(
                new CSVStream<Renovation>(RENOVATION_DB, new RenovationCSVConverter(CSV_DELIMITER)), new LongSequencer());
            var renovationResultDao = new RoomDao(new CSVStream<Room>(RENOVATIONRESULT_DB, new RoomCSVConverter(CSV_DELIMITER)));
            var roomDao = new RoomDao(new CSVStream<Room>(ROOM_DB, new RoomCSVConverter(CSV_DELIMITER)));
            var equipmentDao = new EquipmentDao(new CSVStream<Equipment>(EQUIPMENT_DB, new EquipmentCSVConverter(CSV_DELIMITER)));
            var shiftDao = new ShiftDao(new CSVStream<Shift>(SHIFT_DB, new ShiftCSVConverter(CSV_DELIMITER)), new LongSequencer());
            var workTimeDao = new WorkTimeDao(
                new CSVStream<WorkTime>(WORKTIME_DB, new WorkTimeCSVConverter(CSV_DELIMITER)), new LongSequencer());

/*          var funcDao = new RoomFuncDao(FUNC_DB, CSV_DELIMITER);
            var deptDao = new RoomDepartmentDao(DEPT_DB, CSV_DELIMITER);
            var ingredientDao = new IngredientDao(INGREDIENT_DB, CSV_DELIMITER);
            var medicineDao = new MedicineDao(MEDICINE_DB, CSV_DELIMITER);
            var recoveryRoomDao = new RecoveryRoomDao(RECOVERYROOM_DB, CSV_DELIMITER);
            var roomDao = new RoomDao(ROOM_DB, CSV_DELIMITER);
            var equipmentDao = new EquipmentDao(EQUIPMENT_DB, CSV_DELIMITER);            
            var renovationDao = new RenovationDao(RENOVATION_DB, CSV_DELIMITER);
            var renovationResultDao = new RoomDao(RENOVATIONRESULT_DB, CSV_DELIMITER);
            var shiftDao = new ShiftDao(SHIFT_DB, CSV_DELIMITER);
            var workTimeDao = new WorkTimeDao(WORKTIME_DB, CSV_DELIMITER);
*/
            //Service
            var funcService = new RoomFuncService(funcDao);
            var deptService = new RoomDeptService(deptDao);
            var ingredientService = new IngredientService(ingredientDao);
            var medicineService = new MedicineService(medicineDao, ingredientService);
            var recoveryRoomService = new RecoveryRoomService(recoveryRoomDao);
            var renovationService = new RenovationService(roomDao, renovationResultDao, renovationDao);
            var equipmentService = new EquipmentService(equipmentDao,
                new RoomService(roomDao, deptService, funcService, recoveryRoomService, new EquipmentService(equipmentDao, null)));
            var roomService = new RoomService(roomDao, deptService, funcService, recoveryRoomService, equipmentService);

            var shiftService = new ShiftService(shiftDao);
            var workTimeService = new WorkTimeService(workTimeDao, shiftService);

            //Controller
            funcController = new RoomFuncController(funcService);
            deptController = new RoomDeptController(deptService);
            ingredientController = new IngredientController(ingredientService);
            medicineController = new MedicineController(medicineService);
            recoveryRoomController = new RecoveryRoomController(recoveryRoomService);
            renovationController = new RenovationController(renovationService);
            equipmentController = new EquipmentController(equipmentService);
            roomController = new RoomController(roomService);

            shiftController = new ShiftController(shiftService);
            workTimeController = new WorkTimeController(workTimeService);

            // Departmani koji uvek postoje
            deptController.AddDept(new Department(1, UNDEFINED_DEPT));
            deptController.AddDept(new Department(2, STORAGE_DEPT));
            // Funkcije koje uvek postoje
            funcController.AddFunc(new Functionality(1, UNDEFINED_FUNC));
            funcController.AddFunc(new Functionality(2, STORAGE_FUNC));
            funcController.AddFunc(new Functionality(3, EXAMINATION_FUNC));
            funcController.AddFunc(new Functionality(4, OPERATION_FUNC));
            funcController.AddFunc(new Functionality(5, RECOVERYROOM_FUNC));
            roomController.AddRoom(new Room("MA", 0, new Renovation(), new List<Equipment>(), funcController.GetFunc("Magacin"), deptController.GetDept("Magacin")));
            //List<DayOfWeek> d = new List<DayOfWeek>();
            //d.Add(DayOfWeek.Monday);
            //d.Add(DayOfWeek.Tuesday);
            //d.Add(DayOfWeek.Wednesday);
            //d.Add(DayOfWeek.Thursday);
            //d.Add(DayOfWeek.Friday);
            //shiftController.AddShift(new Shift(new long(), DateTime.Today, DateTime.Today.AddHours(6), d));
            //shiftController.AddShift(new Shift(new long(), DateTime.Today.AddHours(6), DateTime.Today.AddHours(12), d));

            //workTimeController.AddWorkTime(new WorkTime(new long(), 7, DateTime.Today, AssignedShift.iShift, false,
            //    shiftController.GetShift(1), shiftController.GetShift(2)));
            

        }

        public RoomFuncController funcController { get; private set; }
        public RoomDeptController deptController { get; private set; }
        public IngredientController ingredientController { get; private set; }
        public MedicineController medicineController { get; private set; }
        public RecoveryRoomController recoveryRoomController { get; private set; }
        public RenovationController renovationController { get; private set; }
        public RoomController roomController { get; private set; }
        public EquipmentController equipmentController { get; private set; }
        public WorkTimeController workTimeController { get; private set; }
        public ShiftController shiftController { get; private set; }
    }
}
