using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Management;

namespace uBizSoft.FileCopy.fCopy
{
    public partial class Explorer : Form
    {
        public Explorer()
        {
            InitializeComponent();

            PopulateLeftDriveList();
            PopulateRightDriveList();
        }

        private uBizSoft.FileCopy.fCopy.CLibrary m_clibrary = null;
        private uBizSoft.FileCopy.fCopy.CLibrary CLibrary
        {
            get
            {
                if (m_clibrary == null)
                {
                    m_clibrary = new uBizSoft.FileCopy.fCopy.CLibrary();
                }
                return m_clibrary;
            }
        }

        protected void InitLeftListView()
        {
            lvLFiles.Clear();

            lvLFiles.Columns.Add("Name", 150, System.Windows.Forms.HorizontalAlignment.Left);
            lvLFiles.Columns.Add("Size", 75, System.Windows.Forms.HorizontalAlignment.Right);
            lvLFiles.Columns.Add("Created", 140, System.Windows.Forms.HorizontalAlignment.Left);
            lvLFiles.Columns.Add("Modified", 140, System.Windows.Forms.HorizontalAlignment.Left);
        }

        protected void PopulateLeftDirectory(TreeNode p_cnode, TreeNodeCollection p_cols)
        {
            var _imgndx = 2;
            var _selndx = 3;

            if (p_cnode.SelectedImageIndex != 0)
            {
                try
                {
                    if (Directory.Exists(GetLeftFullPath(p_cnode.FullPath)) == false)
                    {
                        MessageBox.Show("Directory or path " + p_cnode.ToString() + " does not exist.");
                    }
                    else
                    {
                        PopulateLeftFiles(p_cnode);

                        var _dirs = Directory.GetDirectories(GetLeftFullPath(p_cnode.FullPath));
                        var _fpath = string.Empty;
                        var _dname = string.Empty;

                        foreach (string _dir in _dirs)
                        {
                            _fpath = _dir;
                            _dname = CLibrary.GetPathName(_fpath);

                            var _nnode = new TreeNode(_dname.ToString(), _imgndx, _selndx);
                            p_cols.Add(_nnode);
                        }
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Error: Drive not ready or directory does not exist. ");
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("Error: Drive or directory access denided. ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
            }
        }

        protected void PopulateLeftDriveList()
        {
            var _imgndx = 0;
            var _selndx = 0;

            Cursor = Cursors.WaitCursor;
            tvLFolders.Nodes.Clear();

            var _tnode = new TreeNode("My Computer", 0, 0);
            tvLFolders.Nodes.Add(_tnode);

            var _tncol = _tnode.Nodes;

            var _drives = GetLeftDrives();
            foreach (ManagementObject _object in _drives)
            {
                switch (int.Parse(_object["DriveType"].ToString()))
                {
                    case CLibrary.Removable:
                        _imgndx = 5;
                        _selndx = 5;
                        break;
                    case CLibrary.LocalDisk:
                        _imgndx = 6;
                        _selndx = 6;
                        break;
                    case CLibrary.CD:
                        _imgndx = 7;
                        _selndx = 7;
                        break;
                    case CLibrary.Network:
                        _imgndx = 8;
                        _selndx = 8;
                        break;
                    default:
                        _imgndx = 2;
                        _selndx = 3;
                        break;
                }

                _tnode = new TreeNode(_object["Name"].ToString() + "\\", _imgndx, _selndx);

                _tncol.Add(_tnode);
            }

            InitLeftListView();

            Cursor = Cursors.Default;
        }

        protected void PopulateLeftFiles(TreeNode p_cnode)
        {
            var lvData = new string[4];

            InitLeftListView();

            if (p_cnode.SelectedImageIndex != 0)
            {
                if (Directory.Exists((string)GetLeftFullPath(p_cnode.FullPath)) == false)
                {
                    MessageBox.Show("Directory or path " + p_cnode.ToString() + " does not exist.");
                }
                else
                {
                    try
                    {
                        var _files = Directory.GetFiles(GetLeftFullPath(p_cnode.FullPath));
                        var _fname = string.Empty;
                        DateTime dtCreateDate, dtModifyDate;
                        var lFileSize = 0;

                        foreach (string _file in _files)
                        {
                            _fname = _file;
                            var _fileinf = new FileInfo(_fname);
                            lFileSize = _fileinf.Length;
                            dtCreateDate = _fileinf.CreationTime;
                            dtModifyDate = _fileinf.LastWriteTime;

                            lvData[0] = CLibrary.GetPathName(_fname);
                            lvData[1] = CLibrary.FormatSize(lFileSize);

                            if (TimeZone.CurrentTimeZone.IsDaylightSavingTime(dtCreateDate) == false)
                            {
                                lvData[2] = CLibrary.FormatDate(dtCreateDate.AddHours(1));
                            }
                            else
                            {
                                lvData[2] = CLibrary.FormatDate(dtCreateDate);
                            }

                            if (TimeZone.CurrentTimeZone.IsDaylightSavingTime(dtModifyDate) == false)
                            {
                                lvData[3] = CLibrary.FormatDate(dtModifyDate.AddHours(1));
                            }
                            else
                            {
                                lvData[3] = CLibrary.FormatDate(dtModifyDate);
                            }

                            var _lvItem = new ListViewItem(lvData, 0);
                            _lvItem.Tag = _fileinf;
                            lvLFiles.Items.Add(_lvItem);
                        }
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Error: Drive not ready or directory does not exist.");
                    }
                    catch (UnauthorizedAccessException)
                    {
                        MessageBox.Show("Error: Drive or directory access denided.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex);
                    }
                }
            }
        }

        protected string GetLeftFullPath(string stringPath)
        {
            var stringParse = string.Empty;
            stringParse = stringPath.Replace("My Computer\\", string.Empty);

            return stringParse;
        }

        protected ManagementObjectCollection GetLeftDrives()
        {
            var _searcher = new ManagementObjectSearcher("SELECT * From Win32_LogicalDisk ");
            var _objects = _searcher.Get();

            return _objects;
        }

        protected void InitRightListView()
        {
            lvRFiles.Clear();

            lvRFiles.Columns.Add("Name", 150, System.Windows.Forms.HorizontalAlignment.Left);
            lvRFiles.Columns.Add("Size", 75, System.Windows.Forms.HorizontalAlignment.Right);
            lvRFiles.Columns.Add("Created", 140, System.Windows.Forms.HorizontalAlignment.Left);
            lvRFiles.Columns.Add("Modified", 140, System.Windows.Forms.HorizontalAlignment.Left);
        }

        protected void PopulateRightDirectory(TreeNode p_cnode, TreeNodeCollection p_cols)
        {
            TreeNode _nodeDir;
            var _imgndx = 2;
            var _selndx = 3;

            if (p_cnode.SelectedImageIndex != 0)
            {
                try
                {
                    if (CLibrary.Channel.Proxy.DirectoryExists(GetRightFullPath(p_cnode.FullPath)) == false)
                    {
                        MessageBox.Show("Directory or path " + p_cnode.ToString() + " does not exist.");
                    }
                    else
                    {
                        PopulateRightFiles(p_cnode);

                        var _directories = CLibrary.Channel.Proxy.GetDirectories(GetRightFullPath(p_cnode.FullPath));
                        var _fullpath = string.Empty;
                        var _pathname = string.Empty;

                        foreach (string _dir in _directories)
                        {
                            _fullpath = _dir;
                            _pathname = CLibrary.GetPathName(_fullpath);

                            _nodeDir = new TreeNode(_pathname.ToString(), _imgndx, _selndx);
                            p_cols.Add(_nodeDir);
                        }
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Error: Drive not ready or directory does not exist.");
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("Error: Drive or directory access denided.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
            }
        }

        protected void PopulateRightDriveList()
        {
            TreeNode _tnode;
            var _imgndx = 0;
            var _selndx = 0;

            Cursor = Cursors.WaitCursor;
            tvRFolders.Nodes.Clear();

            _tnode = new TreeNode("Your Computer", 0, 0);
            tvRFolders.Nodes.Add(_tnode);

            var _tncol = _tnode.Nodes;

            var _folders = CLibrary.Channel.Proxy.GetDrives();
            for (var i = 0; i < _folders.GetLength(0) ; i++)
            {
                switch (int.Parse(_folders[i].DriveType))
                {
                    case CLibrary.Removable:
                        _imgndx = 5;
                        _selndx = 5;
                        break;
                    case CLibrary.LocalDisk:
                        _imgndx = 6;
                        _selndx = 6;
                        break;
                    case CLibrary.CD:
                        _imgndx = 7;
                        _selndx = 7;
                        break;
                    case CLibrary.Network:
                        _imgndx = 8;
                        _selndx = 8;
                        break;
                    default:
                        _imgndx = 2;
                        _selndx = 3;
                        break;
                }

                _tnode = new TreeNode(_folders[i].DriveName + "\\", _imgndx, _selndx);

                _tncol.Add(_tnode);
            }

            InitRightListView();

            Cursor = Cursors.Default;
        }

        protected void PopulateRightFiles(TreeNode nodeCurrent)
        {
            var lvData = new string[4];

            InitRightListView();

            if (nodeCurrent.SelectedImageIndex != 0)
            {
                if (CLibrary.Channel.Proxy.DirectoryExists((string)GetRightFullPath(nodeCurrent.FullPath)) == false)
                {
                    MessageBox.Show("Directory or path " + nodeCurrent.ToString() + " does not exist.");
                }
                else
                {
                    try
                    {
                        var _fileinfs = CLibrary.Channel.Proxy.GetFileInfos(GetRightFullPath(nodeCurrent.FullPath));

                        DateTime dtCreateDate, dtModifyDate;
                        var lFileSize = 0;

                        foreach (uFile _fileinf in _fileinfs)
                        {
                            lFileSize = _fileinf.Length;
                            dtCreateDate = _fileinf.CreationTime;
                            dtModifyDate = _fileinf.LastWriteTime;

                            lvData[0] = CLibrary.GetPathName(_fileinf.FullName);
                            lvData[1] = CLibrary.FormatSize(lFileSize);

                            if (TimeZone.CurrentTimeZone.IsDaylightSavingTime(dtCreateDate) == false)
                            {
                                lvData[2] = CLibrary.FormatDate(dtCreateDate.AddHours(1));
                            }
                            else
                            {
                                lvData[2] = CLibrary.FormatDate(dtCreateDate);
                            }

                            if (TimeZone.CurrentTimeZone.IsDaylightSavingTime(dtModifyDate) == false)
                            {
                                lvData[3] = CLibrary.FormatDate(dtModifyDate.AddHours(1));
                            }
                            else
                            {
                                lvData[3] = CLibrary.FormatDate(dtModifyDate);
                            }

                            var _lvItem = new ListViewItem(lvData, 0);
                            _lvItem.Tag = _fileinf;
                            lvRFiles.Items.Add(_lvItem);
                        }
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Error: Drive not ready or directory does not exist.");
                    }
                    catch (UnauthorizedAccessException)
                    {
                        MessageBox.Show("Error: Drive or directory access denided.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex);
                    }
                }
            }
        }

        protected string GetRightFullPath(string stringPath)
        {
            var stringParse = string.Empty;

            stringParse = stringPath.Replace("Your Computer\\", string.Empty);

            return stringParse;
        }

        private void miClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tvLFolders_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            var _cnode = e.Node;

            _cnode.Nodes.Clear();

            if (_cnode.SelectedImageIndex == 0)
            {
                PopulateLeftDriveList();
            }
            else
            {
                PopulateLeftDirectory(_cnode, _cnode.Nodes);
            }

            Cursor = Cursors.Default;
        }

        private void tvRFolders_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            var _cnode = e.Node;

            _cnode.Nodes.Clear();

            if (_cnode.SelectedImageIndex == 0)
            {
                PopulateRightDriveList();
            }
            else
            {
                PopulateRightDirectory(_cnode, _cnode.Nodes);
            }

            Cursor = Cursors.Default;
        }

        private int m_progress = 0;

        private void btnMoveToLeft_Click(object sender, EventArgs e)
        {
            if (m_progress < 1)
            {
                m_progress++;

                var _cpath = GetLeftFullPath(tvLFolders.SelectedNode.FullPath);

                var i = 0;

                var _files = new uFile[lvRFiles.SelectedIndices.Count];
                foreach (int _ndx in lvRFiles.SelectedIndices)
                {
                    _files[i++] = lvRFiles.Items[_ndx].Tag as uFile;
                }
                for (i--; i >= 0; i--)
                {
                    var _cfile = Path.Combine(_cpath, _files[i].Name);
                    sbStatus.Text = _cfile;

                    if (File.Exists(_cfile) == true)
                    {
                        File.Delete(_cfile);
                    }
                    CLibrary.DownloadServerFile(_files[i].FullName, _cfile, _files[i].Length, 0);
                }

                sbStatus.Text = String.Format("{0} Files Copied...", _files.Length);

                m_progress--;
            }
        }

        private void btnMoveToRight_Click(object sender, EventArgs e)
        {
        }

        private void tvLFolders_AfterExpand(object sender, TreeViewEventArgs e)
        {
        }
    }
}
