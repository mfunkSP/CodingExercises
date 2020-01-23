
// InterviewTestDlg.h : header file
//

#pragma once
#include "afxwin.h"


// CInterviewTestDlg dialog
class CInterviewTestDlg : public CDialogEx
{
// Construction
public:
	CInterviewTestDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_INTERVIEWTESTCORRECT_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
	CComboBox m_comboEntries;
	CEdit m_editValue;
public:
	afx_msg void OnBnClickedRadioShapes();
	afx_msg void OnBnClickedRadioColors();
	afx_msg void OnBnClickedRadioPatterns();
	afx_msg void OnCbnSelchangeComboEntries();
	virtual void OnOK();
};
