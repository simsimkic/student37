using Model.Patient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlinikaFront.DB
{
    class QuestionsDB
    {
        private QuestionsDB() { }
        public static QuestionsDB Instance { get; } = new QuestionsDB();
        public ObservableCollection<Question> Questions { get; set; } = new ObservableCollection<Question>();
    }
}
