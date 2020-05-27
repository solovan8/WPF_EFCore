using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using WPf_EFCore.Buisiness.Interfaces;
using WPf_EFCore.Model;

namespace WPf_EFCore.VM
{
    class TopicViewModel : INotifyPropertyChanged
    {
        private readonly ITopicService topicService;
        private readonly IQuizService quizService;
        public TopicViewModel(ITopicService topicService, IQuizService quizService)
        {
            this.topicService = topicService;
            this.quizService = quizService;
            //var topic = topicService.GetAllTopics();
            //MessageBox.Show(topic.FirstOrDefault().Text);
            //MessageBox.Show(topic.Text);
            //MessageBox.Show(topicService.GetTopicById(1).Text);
            var topic = new Topic("from constructor");
            topicService.CreateTopic(topic);
            //MessageBox.Show(topic.Text);
        }
        private string _topicCreate;
        private string _topicQuestion;
        private string _question;
        private string _quizTopic;

        private string _trueAnswer;
        private string _falseAnswer0;
        private string _falseAnswer1;
        private string _falseAnswer2;

        private string _buttonAnswer0;
        private string _buttonAnswer1;
        private string _buttonAnswer2;
        private string _buttonAnswer3;
        private int _trueCounter = 0;
        private int _falseCounter = 0;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public string ButtonAnswer0
        {
            get { return _buttonAnswer0; }
            set
            {
                _buttonAnswer0 = value;
                OnPropertyChanged("ButtonAnswer0");
            }

        }
        public string ButtonAnswer1
        {
            get { return _buttonAnswer1; }
            set
            {
                _buttonAnswer1 = value;
                OnPropertyChanged("ButtonAnswer1");
            }

        }
        public string ButtonAnswer2
        {
            get { return _buttonAnswer2; }
            set
            {
                _buttonAnswer2 = value;
                OnPropertyChanged("ButtonAnswer2");
            }

        }
        public string ButtonAnswer3
        {
            get { return _buttonAnswer3; }
            set
            {
                _buttonAnswer3 = value;
                OnPropertyChanged("ButtonAnswer3");
            }

        }
        public int TrueCounter
        {
            get { return _trueCounter; }
            set
            {
                _trueCounter = value;
                OnPropertyChanged("TrueCounter");
            }

        }
        public int FalseCounter
        {
            get { return _falseCounter; }
            set
            {
                _falseCounter = value;
                OnPropertyChanged("FalseCounter");
            }

        }

        public string TrueAnswer
        {
            get { return _trueAnswer; }
            set
            {
                _trueAnswer = value;
                OnPropertyChanged("TrueAnswer");
            }

        }
        public string FalseAnswer0
        {
            get { return _falseAnswer0; }
            set
            {
                if (value != "")
                {
                    _falseAnswer0 = value;
                    OnPropertyChanged("FalseAnswer-");
                }
            }
        }
        public string FalseAnswer1
        {
            get { return _falseAnswer1; }
            set
            {
                if (value != "")
                {
                    _falseAnswer1 = value;
                    OnPropertyChanged("FalseAnswer1");
                }
            }
        }
        public string FalseAnswer2
        {
            get { return _falseAnswer2; }
            set
            {
                if (value != "")
                {
                    _falseAnswer2 = value;
                    OnPropertyChanged("FalseAnswer2");
                }
            }
        }

        public string TopicCreate
        {
            get { return _topicCreate; }
            set
            {
                if (value != "")
                {
                    _topicCreate = value;
                    OnPropertyChanged("TopicCreate");
                }
            }
        }
        public string TopicQuestion
        {
            get { return _topicQuestion; }
            set
            {
                if (value != "")
                {
                    _topicQuestion = value;
                    OnPropertyChanged("TopicQuestion");
                }
            }
        }
        public string Question
        {
            get { return _question; }
            set
            {
                if (value != "")
                {
                    _question = value;
                    OnPropertyChanged("Age");
                }
            }
        }
        public string QuizTopic
        {
            get { return _quizTopic; }
            set
            {
                _quizTopic = value;
                OnPropertyChanged("QuizTopic");
            }

        }

        private RelayCommand createTopic;
        public RelayCommand CreateTopic
        {
            get
            {
                return createTopic ??
                    (createTopic = new RelayCommand(obj =>
                    {
                        topicService.CreateTopic(topicService.Create(TopicCreate));

                    }));
            }
        }

        private RelayCommand createQuestion;
        public RelayCommand CreateQuestion
        {
            get
            {
                return createQuestion ??
                    (createQuestion = new RelayCommand(obj =>
                    {
                        var chosenTopic = topicService.GetTopicByName(TopicQuestion);
                        topicService.CreateQuestion(chosenTopic, TopicQuestion, TrueAnswer, FalseAnswer0, FalseAnswer1, FalseAnswer2);
                        Question = null;
                        TopicQuestion = null;
                        TrueAnswer = null;
                        FalseAnswer0 = null;
                        FalseAnswer1 = null;
                        FalseAnswer2 = null;
                    }
                    ));
            }
        }

        private RelayCommand chooseTopic;
        public RelayCommand ChooseTopic
        {
            get
            {
                return chooseTopic ??
                    (chooseTopic = new RelayCommand(obj =>
                    {
                        var answers = quizService.Quiz(topicService.GetTopicByName(QuizTopic));
                        ButtonAnswer0 = answers[0].Text;
                        ButtonAnswer1 = answers[1].Text;
                        ButtonAnswer2 = answers[2].Text;
                        ButtonAnswer3 = answers[3].Text;
                    }));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
