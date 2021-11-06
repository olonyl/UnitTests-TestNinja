using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    class HouseKeeperServiceTests
    {
        private Mock<IUnitOfWork> _unitOfWork;
        private Mock<IStatementGenerator>  _statementGenerator;
        private Mock<IEmailSender>  _emailSender;
        private Mock<IXtraMessageBox> _messageBox;
        private HousekeeperService _service;
        private DateTime _statementDate = new DateTime(2017, 1, 1);
        private Housekeeper _housekeeper;
        private string _statementFileName;

        [SetUp]
        public void SetUp()
        {
            _housekeeper = new Housekeeper { Email = "a", FullName = "b", Oid = 1, StatementEmailBody = "c" };

            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(uow => uow.Query<Housekeeper>()).Returns(new List<Housekeeper>
            {
                _housekeeper
            }.AsQueryable());

            _statementFileName = "fileName";
            _statementGenerator = new Mock<IStatementGenerator>();
            _statementGenerator.Setup(sg => sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, _statementDate))
                              .Returns(()=> _statementFileName);

            _emailSender = new Mock<IEmailSender>();
            _messageBox = new Mock<IXtraMessageBox>();

            _service = new HousekeeperService(_unitOfWork.Object, 
                                              _statementGenerator.Object, 
                                              _emailSender.Object, 
                                              _messageBox.Object);

        }
        [Test]
        public void SendStatementEmails_WhenCalled_GenerateStatements()
        {
            _service.SendStatementEmails(_statementDate);
            _statementGenerator.Verify(sg => 
                            sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, _statementDate));
        }

        [Test]
        public void SendStatementEmails_HouseKeeperEmailIsNull_ShouldNotGenerateStatements()
        {
            _housekeeper.Email = null;
            _service.SendStatementEmails(_statementDate);
            _statementGenerator.Verify(sg =>
                            sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, _statementDate),times:Times.Never);
        }

        [Test]
        public void SendStatementEmails_HouseKeeperEmailIsWhiteSpace_ShouldNotGenerateStatements()
        {
            _housekeeper.Email = " ";
            _service.SendStatementEmails(_statementDate);
            _statementGenerator.Verify(sg =>
                            sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, _statementDate), times: Times.Never);
        }

        [Test]
        public void SendStatementEmails_HouseKeeperEmailIsEmptyString_ShouldNotGenerateStatements()
        {
            _housekeeper.Email = "";
            _service.SendStatementEmails(_statementDate);
            _statementGenerator.Verify(sg =>
                            sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, _statementDate), times: Times.Never);
        }

        [Test]
        public void SendStatementEmails_WhenCalled_EmailTheStatement()
        {
            _service.SendStatementEmails(_statementDate);

            VerifyEmailSent();
        }

        [Test]
        public void SendStatementEmails_StatementFileNameIsNull_ShouldNotEmailTheStatement()
        {
            _statementFileName = null;

            _service.SendStatementEmails(_statementDate);

            VerifyEmailNotSent();
        }

        [Test]
        public void SendStatementEmails_StatementFileNameIsEmptyString_ShouldNotEmailTheStatement()
        {
            _statementFileName = string.Empty;

            _service.SendStatementEmails(_statementDate);

            VerifyEmailNotSent();
        }

        [Test]
        public void SendStatementEmails_StatementFileNameIsEmptyWhiteSpace_ShouldNotEmailTheStatement()
        {
            _statementFileName = " ";

            _service.SendStatementEmails(_statementDate);

            VerifyEmailNotSent();
        }

        [Test]
        public void SendStatementEmails_EmailSendingFails_DisplayAMessageBox()
        {
            _emailSender.Setup(es => es.EmailFile(
                It.IsAny<string>(), 
                It.IsAny<string>(), 
                It.IsAny<string>(), 
                It.IsAny<string>())).Throws<Exception>();

            _service.SendStatementEmails(_statementDate);

            _messageBox.Verify(v => v.Show(It.IsAny<string>(), It.IsAny<string>(), MessageBoxButtons.OK));
        }

        private void VerifyEmailSent()
        {
            _emailSender.Verify(sg => sg.EmailFile(_housekeeper.Email,
                                                                _housekeeper.StatementEmailBody,
                                                                _statementFileName,
                                                                It.IsAny<string>()));
        }

        private void VerifyEmailNotSent()
        {
            _emailSender.Verify(es => es.EmailFile(It.IsAny<string>(),
                                                   It.IsAny<string>(),
                                                   It.IsAny<string>(),
                                                   It.IsAny<string>()), times: Times.Never);
        }
    }
}
