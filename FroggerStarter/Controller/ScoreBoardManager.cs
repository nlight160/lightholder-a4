using System;
using FroggerStarter.IO;
using FroggerStarter.Model;
using FroggerStarter.ViewModel;

namespace FroggerStarter.Controller
{
    /// <summary>
    ///     Represents a score board
    /// </summary>
    public class ScoreBoardManager
    {
        #region Data members

        /// <summary>
        ///     The score board
        /// </summary>
        public ScoreBoard ScoreBoard;

        /// <summary>
        ///     The file reader
        /// </summary>
        public FileReader FileReader;

        /// <summary>
        ///     The save file
        /// </summary>
        public SaveFileWriter SaveFile;

        /// <summary>
        /// </summary>
        public ScoreBoardViewModel viewModel;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ScoreBoardManager" /> class.
        ///     Precondition: none
        ///     Postcondition: A new scoreboard manager is created
        /// </summary>
        public ScoreBoardManager()
        {
            this.ScoreBoard = new ScoreBoard();
            this.FileReader = new FileReader();
            this.SaveFile = new SaveFileWriter();
            this.viewModel = new ScoreBoardViewModel();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Adds the new score.
        ///     Precondition: score != null
        ///     Postcondition: score is serialized and saved
        /// </summary>
        /// <param name="score">The score.</param>
        public void AddNewScore(Score score)
        {
            if (score == null)
            {
                throw new ArgumentNullException(nameof(score));
            }

            this.ScoreBoard.Add(score);
        }

        /// <summary>
        ///     Reads the high score.
        ///     Precondition: none
        ///     PostCondition: Scores are
        /// </summary>
        public void ReadHighScore()
        {
            this.FileReader.ReadCurrentFile();
            this.ScoreBoard = this.FileReader.ScoreBoard;

            this.viewModel.ScoreBoard = this.ScoreBoard;
            this.viewModel.UpdateScores();
        }

        /// <summary>
        ///     Saves the new score.
        ///     Precondition: score != null
        ///     PostCondition: score is saved to the file
        /// </summary>
        /// <param name="score">The score.</param>
        /// <exception cref="ArgumentNullException">score</exception>
        public void SaveNewScore(Score score)
        {
            if (score == null)
            {
                throw new ArgumentNullException(nameof(score));
            }

            this.SaveFile.SaveAFile(score);
        }

        #endregion
    }
}