
// InterviewTestDlg.cpp : implementation file
//

#include "stdafx.h"
#include "InterviewTestCorrect.h"
#include "InterviewTestDlg.h"
#include "afxdialogex.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

// CInterviewTestDlg dialog

CInterviewTestDlg::CInterviewTestDlg(CWnd* pParent /*=NULL*/)
	: CDialogEx(CInterviewTestDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CInterviewTestDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_COMBO_ENTRIES, m_comboEntries);
	DDX_Control(pDX, IDC_EDIT_VALUE, m_editValue);
}

BEGIN_MESSAGE_MAP(CInterviewTestDlg, CDialogEx)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_RADIO_SHAPES, &CInterviewTestDlg::OnBnClickedRadioShapes)
	ON_BN_CLICKED(IDC_RADIO_COLORS, &CInterviewTestDlg::OnBnClickedRadioColors)
	ON_BN_CLICKED(IDC_RADIO_PATTERNS, &CInterviewTestDlg::OnBnClickedRadioPatterns)
	ON_CBN_SELCHANGE(IDC_COMBO_ENTRIES, &CInterviewTestDlg::OnCbnSelchangeComboEntries)
END_MESSAGE_MAP()

// CInterviewTestDlg message handlers

BOOL CInterviewTestDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	// TODO: Add extra initialization here

	return TRUE;  // return TRUE  unless you set the focus to a control
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CInterviewTestDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialogEx::OnPaint();
	}
}

// The system calls this function to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CInterviewTestDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

void CInterviewTestDlg::OnBnClickedRadioShapes()
{
	m_comboEntries.ResetContent();
	m_editValue.SetWindowTextW((CString)"");

	m_comboEntries.AddString((CString)"Circle");
	m_comboEntries.AddString((CString)"Square");
	m_comboEntries.AddString((CString)"Triangle");
	m_comboEntries.AddString((CString)"Dodecahedron");
}

void CInterviewTestDlg::OnBnClickedRadioColors()
{
	m_comboEntries.ResetContent();
	m_editValue.SetWindowTextW((CString)"");

	m_comboEntries.AddString((CString)"Blue");
	m_comboEntries.AddString((CString)"Red");
	m_comboEntries.AddString((CString)"Yellow");
	m_comboEntries.AddString((CString)"Puce");
}

void CInterviewTestDlg::OnBnClickedRadioPatterns()
{
	m_comboEntries.ResetContent();
	m_editValue.SetWindowTextW((CString)"");

	m_comboEntries.AddString((CString)"Solid");
	m_comboEntries.AddString((CString)"Striped");
	m_comboEntries.AddString((CString)"Checkered");
	m_comboEntries.AddString((CString)"Paisley");
}

void CInterviewTestDlg::OnCbnSelchangeComboEntries()
{
	int nSel = m_comboEntries.GetCurSel();
	if (nSel == CB_ERR)
		return;

	CString strText;
	m_comboEntries.GetLBText(nSel, strText);

	m_editValue.SetWindowTextW(strText);
}


void CInterviewTestDlg::OnOK()
{
	OutputDebugString((CString)"Closing dialog\n");

	CDialogEx::OnOK();
}
