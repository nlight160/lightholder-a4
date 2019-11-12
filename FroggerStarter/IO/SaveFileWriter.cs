﻿using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using FroggerStarter.Model;

namespace FroggerStarter.IO
{
    /// <summary>
    ///     Saves and writes to xml file
    /// </summary>
    public class SaveFileWriter
    {
        #region Methods

        /// <summary>
        ///     Saves a file asynchronous.
        ///     Precondition: score != null
        ///     Postcondition: score is serialized and saved
        /// </summary>
        /// <param name="score">The score.</param>
        public void SaveAFile(Score score)
        {
            if (score == null)
            {
                throw new ArgumentNullException(nameof(score));
            }

            var fileName = "HighScoreBoard.xml";
            var projectDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var path = Path.Combine(projectDirectory, fileName);

            var xmlWriterSettings = new XmlWriterSettings {
                Indent = true,
                NewLineOnAttributes = true
            };
            using (var xmlWriter = XmlWriter.Create(path, xmlWriterSettings))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("Score");
                xmlWriter.WriteStartElement(score.Name);
                xmlWriter.WriteAttributeString("Value", score.Value.ToString());
                xmlWriter.WriteAttributeString("Level", score.Level.ToString());
                xmlWriter.WriteEndElement();
                xmlWriter.Flush();

                var serializer = new XmlSerializer(typeof(Score));
                serializer.Serialize(xmlWriter, score);
                xmlWriter.WriteEndDocument();
                xmlWriter.Close();
            }
        }

        #endregion
    }
}