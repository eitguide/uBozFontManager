using FontManager.Callback;
using FontManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FontManager.FontService
{

    public class SearchEngine
    {

        public event SearchFinishedHandler ListenerSearchFinished;
        public event SearchFailedHandler ListenerSearchFailed;

        private List<FontInfo> SearchResult = new List<FontInfo>();

        public class SearchData
        {
            public List<FontInfo> Source { get; set; }
            public string Keyword { get; set; }
            public int Start { get; set; }
            public int End { get; set; }
            public SearchType SearchType { get; set; }
        }

        public void FindFont(List<FontInfo> dataSource, string keyword, int lenghtConstraint, SearchType searchType = SearchType.All)
        {
            int NumberThread = 3;
            if (String.IsNullOrEmpty(keyword) && keyword.Length <= lenghtConstraint)
            {
                if (ListenerSearchFailed != null)
                {
                    ListenerSearchFailed.Invoke(this, new SearchFailedEventArgs("Not Contrains"));
                    return;
                }
            }


            if (this.SearchResult != null && this.SearchResult.Count > 0)
                this.SearchResult.Clear();

            Thread searchThread1 = new Thread(x => SearchInBackground(x));
            Thread searchThread2 = new Thread(x => SearchInBackground(x));


            int midule = dataSource.Count / 2;

            searchThread1.Start(new SearchData
            {
                Source = dataSource,
                Start = 0,
                End = midule,
                SearchType = searchType,
                Keyword = keyword
            });

            searchThread2.Start(new SearchData
            {
                Source = dataSource,
                Start = midule + 1,
                End = dataSource.Count,
                SearchType = searchType,
                Keyword = keyword
            });


        }


        int n_thread = 2;

        FinishData finishedData = new FinishData();
        private void SearchInBackground(object dataSearch)
        {
            SearchData data = dataSearch as SearchData;

            for (int i = data.Start; i < data.End; i++)
            {
                switch (data.SearchType)
                {
                    case SearchType.All:

                        string subsetsA = data.Source[i].SubsetString;
                        if (subsetsA != null && (subsetsA.Contains(data.Keyword) || subsetsA.ToLower().Contains(data.Keyword)))
                        {
                            this.SearchResult.Add(data.Source[i]);
                        }

                        string copyRightA = data.Source[i].StringLanguageSupported;
                        if (copyRightA != data.Source[i].Copyright && copyRightA.Contains(data.Keyword))
                        {
                            this.SearchResult.Add(data.Source[i]);
                        }

                        string designerA = data.Source[i].Designer;
                        if (designerA != null && designerA.Contains(data.Keyword))
                        {
                            this.SearchResult.Add(data.Source[i]);
                        }

                        string familyA = data.Source[i].FontFamily;
                        if (familyA != null && familyA.Contains(data.Keyword))
                        {
                            this.SearchResult.Add(data.Source[i]);
                        }

                        string fileNameA = data.Source[i].NameInRegistry;
                        if (fileNameA != null && fileNameA.Contains(data.Keyword))
                        {
                            this.SearchResult.Add(data.Source[i]);
                        }

                        string langA = data.Source[i].StringLanguageSupported;
                        if (langA != null && langA.Contains(data.Keyword))
                            this.SearchResult.Add(data.Source[i]);
                       

                        string manufactuerA = data.Source[i].Manufacturer;
                        if (manufactuerA != null && manufactuerA.Contains(data.Keyword))
                        {
                            this.SearchResult.Add(data.Source[i]);
                        }

                        string postscriptA = data.Source[i].PostscriptName;
                        if (postscriptA != null && postscriptA.Contains(data.Keyword))
                        {
                            this.SearchResult.Add(data.Source[i]);
                        }

                        string styleA = data.Source[i].FontSubFamily;
                        if (styleA != null && styleA.Contains(data.Keyword))
                        {
                            this.SearchResult.Add(data.Source[i]);
                        }
                        break;

                    case SearchType.Copyright:
                        string copyRight = data.Source[i].Copyright;
                        if (copyRight != null && copyRight.Contains(data.Keyword))
                        {
                            this.SearchResult.Add(data.Source[i]);
                        }
                        break;
                    case SearchType.Designer:
                        string designer = data.Source[i].Designer;
                        if (designer != null && designer.Contains(data.Keyword))
                        {
                            this.SearchResult.Add(data.Source[i]);
                        }
                        break;

                    case SearchType.Family:
                        string family = data.Source[i].FontFamily;
                        if (family != null && family.Contains(data.Keyword))
                        {
                            this.SearchResult.Add(data.Source[i]);
                        }
                        break;
                    case SearchType.FileName:
                        string fileName = data.Source[i].FileNameInRegistry;
                        if (fileName != null && fileName.Contains(data.Keyword))
                        {
                            this.SearchResult.Add(data.Source[i]);
                        }
                        break;
                    case SearchType.Language:
                        string lang = data.Source[i].StringLanguageSupported;
                        if (lang != null && lang.Contains(data.Keyword))
                            this.SearchResult.Add(data.Source[i]);
                        break;
                    case SearchType.Manufactuer:
                        string manufactuer = data.Source[i].Manufacturer;
                        if (manufactuer != null && manufactuer.Contains(data.Keyword))
                        {
                            this.SearchResult.Add(data.Source[i]);
                        }
                        break;
                    case SearchType.PostScript:
                        string postscript = data.Source[i].PostscriptName;
                        if (postscript != null && postscript.Contains(data.Keyword))
                        {
                            this.SearchResult.Add(data.Source[i]);
                        }
                        break;
                    case SearchType.Style:
                        string style = data.Source[i].FontSubFamily;
                        if (style != null && style.Contains(data.Keyword))
                        {
                            this.SearchResult.Add(data.Source[i]);
                        }
                        break;

                    case SearchType.Subset:
                        string subsets = data.Source[i].SubsetString;
                        if (subsets != null && (subsets.Contains(data.Keyword) || subsets.ToLower().Contains(data.Keyword)))
                        {
                            this.SearchResult.Add(data.Source[i]);
                        }
                        break;
                      
                    default:
                        break;
                }
            }

            lock (finishedData)
            {
                finishedData.FinisedTask++;
                if(finishedData.FinisedTask == n_thread)
                {
                    finishedData.FinisedTask = 0;
                    if (ListenerSearchFinished != null)
                    {
                        ListenerSearchFinished(this, new SearchFinishedEventArgs(this.SearchResult));
                    }
                }
                
            }
           
        }


        public class FinishData
        {
            public int FinisedTask { get; set; }

            public FinishData()
            {
                FinisedTask = 0;
            }
        }

    }
}
